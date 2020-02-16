using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static JassParser;

namespace JassToCsMain
{
    class JassVisitor : JassBaseVisitor<string>
    {
        #region Inherited

        public override string Visit(IParseTree tree)
        {
            if (tree != null)
            {
                return tree.Accept(this);
            }

            return string.Empty;
        }

        public override string VisitChildren(IRuleNode node)
        {
            if (node != null)
            {
                return base.VisitChildren(node);
            }

            return string.Empty;
        }

        public override string VisitTerminal(ITerminalNode node)
        {
            return node.Symbol.Text;
        }

        protected override string AggregateResult(string aggregate, string nextResult)
        {
            return aggregate != null
                ? aggregate + nextResult
                : nextResult;
        }

        public override string VisitErrorNode(IErrorNode node)
        {
            return null;
        }

        #endregion

        #region Custom code

        public string VisitChildrens(IList<IParseTree> nodes, string separator = "")
        {
            if (nodes != null)
            {
                StringBuilder stringBuilder = new StringBuilder(string.Empty);

                for (int i = 0; i < nodes.Count - 1; i++)
                {
                    var node = nodes[i];
                    stringBuilder.Append($"{this.Visit(node)}{separator}");
                }

                stringBuilder.Append($"{this.Visit(nodes[nodes.Count - 1])}");

                return stringBuilder.ToString();
            }

            return string.Empty;
        }

        public override string VisitArgs([NotNull] JassParser.ArgsContext context)
        {
            return base.VisitArgs(context);
        }

        public override string VisitArray_ref([NotNull] JassParser.Array_refContext context)
        {
            return base.VisitArray_ref(context);
        }

        public override string VisitBoolConst([NotNull] JassParser.BoolConstContext context)
        {
            return base.VisitBoolConst(context);
        }

        public override string VisitCall([NotNull] JassParser.CallContext context)
        {
            // Remove call keyword
            context.children?.RemoveAt(0);

            return base.VisitCall(context);
        }

        public override string VisitConstant([NotNull] JassParser.ConstantContext context)
        {
            return base.VisitConstant(context);
        }

        public override string VisitDebug([NotNull] JassParser.DebugContext context)
        {
            return base.VisitDebug(context);
        }

        public override string VisitDeclr([NotNull] JassParser.DeclrContext context)
        {
            return base.VisitDeclr(context);
        }

        public override string VisitElse_clause([NotNull] JassParser.Else_clauseContext context)
        {
            var statement_list = this.Visit(context.statement_list());
            if (context.K_ELSEIF() != null)
            {
                var expr = this.Visit(context.expr());
                var else_clause = this.Visit(context.else_clause());

                return $"\nelse {{\nif({expr}) {{\n{statement_list}}}{else_clause}}}";
            }
            else
            {
                return $"\nelse {{\n{statement_list}}}";
            }
        }

        public override string VisitExitwhen([NotNull] JassParser.ExitwhenContext context)
        {
            return $"if ({this.Visit(context.expr())}) {{ break; }}";
        }

        public override string VisitExpr([NotNull] JassParser.ExprContext context)
        {
            Helper.ReplaceBinaryOperator(context);

            if (Helper.IsIntegerDivision(context))
            {
                return $"R2I({base.VisitExpr(context)})";
            }

            if (Helper.IsStringConcatenation(context))
            {
                return $"S2S({base.VisitExpr(context)})";
            }

            // Optional
            if (Helper.IsFourccConcatenation(context))
            {
                var expressions = context.expr();
                var fourcc1 = expressions[0]?.constant()?.int_const()?.FOURCC().Symbol.Text;
                var fourcc2 = expressions[1]?.constant()?.int_const()?.FOURCC().Symbol.Text;

                if (fourcc1== "'½·ó4'")
                {

                }

                // 0 and 5 are parenteses
                int num1 = (sbyte)fourcc1[1] * 256 * 256 * 256 + (sbyte)fourcc1[2] * 256 * 256 + (sbyte)fourcc1[3] * 256 + (sbyte)fourcc1[4];
                int num2 = (sbyte)fourcc2[1] * 256 * 256 * 256 + (sbyte)fourcc2[2] * 256 * 256 + (sbyte)fourcc2[3] * 256 + (sbyte)fourcc2[4];
                int num3 = num1 + num2;

                return num3.ToString();
            }

            return base.VisitExpr(context);
        }

        public override string VisitFile([NotNull] JassParser.FileContext context)
        {
            return base.VisitFile(context);
        }

        public override string VisitFunc([NotNull] JassParser.FuncContext context)
        {
            Helper.FillLocalTypes(context);

            var func_declr = this.Visit(context.func_declr());
            var local_var_list = this.Visit(context.local_var_list());
            var statement_list = this.Visit(context.statement_list());

            return $"function {func_declr}{local_var_list}{statement_list}}}\n";
        }

        public override string VisitFunc_call([NotNull] JassParser.Func_callContext context)
        {
            return base.VisitFunc_call(context);
        }

        public override string VisitFunc_declr([NotNull] JassParser.Func_declrContext context)
        {
            Helper.functionTypes.Add(context.id().GetText(), context.type()?.GetText());

            return $"{context.id().GetText()}({this.Visit(context.param_list())}) {{\n";
        }

        public override string VisitFunc_ref([NotNull] JassParser.Func_refContext context)
        {
            return $"{context.id().GetText()}";
        }

        public override string VisitGlobals([NotNull] JassParser.GlobalsContext context)
        {
            return this.Visit(context.global_var_list());
        }

        public override string VisitGlobal_var_list([NotNull] JassParser.Global_var_listContext context)
        {
            Helper.FillGlobalTypes(context);

            return base.VisitGlobal_var_list(context);
        }

        public override string VisitGlobal_var_declr([NotNull] Global_var_declrContext context)
        {
            if (context.K_CONSTANT() != null)
            {
                context.children.RemoveAt(0);
            }

            return base.VisitGlobal_var_declr(context);
        }

        public override string VisitIfthenelse([NotNull] JassParser.IfthenelseContext context)
        {
            return $"if ({this.Visit(context.expr())}) {{\n{this.Visit(context.statement_list())}}}{this.Visit(context.else_clause())}"; ;
        }

        public override string VisitInt_const([NotNull] JassParser.Int_constContext context)
        {
            Helper.ReplaceHex(context);

            return base.VisitInt_const(context);
        }

        public override string VisitLocal_var_list([NotNull] JassParser.Local_var_listContext context)
        {
            return base.VisitLocal_var_list(context);
        }

        public override string VisitLocal_var_declr([NotNull] JassParser.Local_var_declrContext context)
        {
            // Remove local keyword
            context.children?.RemoveAt(0);

            return base.VisitLocal_var_declr(context);
        }

        public override string VisitLoop([NotNull] JassParser.LoopContext context)
        {
            return $"do {{\n{this.Visit(context.statement_list())}}} while(true)";
        }

        public override string VisitNative_func([NotNull] JassParser.Native_funcContext context)
        {
            return $"function {this.Visit(context.func_declr())}}}";
        }

        public override string VisitParam_list([NotNull] JassParser.Param_listContext context)
        {
            return this.VisitChildrens(context.id(), ",");
        }

        public override string VisitParens([NotNull] JassParser.ParensContext context)
        {
            return base.VisitParens(context);
        }

        public override string VisitReturn_stat([NotNull] JassParser.Return_statContext context)
        {
            return this.VisitChildrens(context.children, " ");
        }

        public override string VisitSet([NotNull] JassParser.SetContext context)
        {
            // Remove set keyword
            context.children?.RemoveAt(0);

            return base.VisitSet(context);
        }

        public override string VisitStatement([NotNull] JassParser.StatementContext context)
        {
            return $"{base.VisitStatement(context)}";
        }

        public override string VisitStatement_list([NotNull] JassParser.Statement_listContext context)
        {
            return base.VisitStatement_list(context);
        }

        public override string VisitType([NotNull] JassParser.TypeContext context)
        {
            return "var ";
        }

        public override string VisitTypedef([NotNull] JassParser.TypedefContext context)
        {
            return string.Empty;
        }

        public override string VisitVar_declr([NotNull] JassParser.Var_declrContext context)
        {
            if (context.K_ARRAY() != null)
            {
                // Remove array keyword
                context.children?.RemoveAt(1);

                return $"{base.VisitVar_declr(context)} = [];";
            }

            return $"{base.VisitVar_declr(context)};";
        }

        public override string VisitStringConst([NotNull] StringConstContext context)
        {
            var stringConst = base.VisitStringConst(context);

            Regex regex = new Regex("[\r\n]");
            if (regex.IsMatch(stringConst))
            {
                return regex.Replace(stringConst, string.Empty);
            }

            return stringConst;
        }

        public override string VisitId([NotNull] IdContext context)
        {
            var id = base.VisitId(context);

            return Helper.ReplaceInvalidVariableName(id);
        }

        #endregion
    }
}
