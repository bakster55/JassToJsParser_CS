using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using static JassParser;

namespace JassToCsMain
{
    class JassVisitor : JassBaseVisitor<StringBuilder>
    {
        #region Inherited

        public override StringBuilder Visit(IParseTree tree)
        {
            if (tree != null)
            {
                return tree.Accept(this);
            }

            return new StringBuilder(string.Empty);
        }

        public override StringBuilder VisitChildren(IRuleNode node)
        {
            if (node != null)
            {
                return base.VisitChildren(node);
            }

            return new StringBuilder(string.Empty);
        }

        public override StringBuilder VisitTerminal(ITerminalNode node)
        {
            return new StringBuilder(node.Symbol.Text);
        }

        protected override StringBuilder AggregateResult(StringBuilder aggregate, StringBuilder nextResult)
        {
            return aggregate != null
                ? aggregate.Append(nextResult)
                : nextResult;
        }

        public override StringBuilder VisitErrorNode(IErrorNode node)
        {
            return null;
        }

        #endregion

        #region Custom code

        public StringBuilder VisitChildrens(IList<IParseTree> nodes, string separator = "")
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

                return stringBuilder;
            }

            return new StringBuilder(string.Empty);
        }

        public override StringBuilder VisitArgs([NotNull] JassParser.ArgsContext context)
        {
            return base.VisitArgs(context);
        }

        public override StringBuilder VisitArray_ref([NotNull] JassParser.Array_refContext context)
        {
            return base.VisitArray_ref(context);
        }

        public override StringBuilder VisitBoolConst([NotNull] JassParser.BoolConstContext context)
        {
            return base.VisitBoolConst(context);
        }

        public override StringBuilder VisitCall([NotNull] JassParser.CallContext context)
        {
            // Remove call keyword
            context.children?.RemoveAt(0);

            return base.VisitCall(context);
        }

        public override StringBuilder VisitConstant([NotNull] JassParser.ConstantContext context)
        {
            return base.VisitConstant(context);
        }

        public override StringBuilder VisitDebug([NotNull] JassParser.DebugContext context)
        {
            return base.VisitDebug(context);
        }

        public override StringBuilder VisitDeclr([NotNull] JassParser.DeclrContext context)
        {
            return new StringBuilder($"{base.VisitDeclr(context)}{Environment.NewLine}");
        }

        public override StringBuilder VisitElse_clause([NotNull] JassParser.Else_clauseContext context)
        {
            var statement_list = this.Visit(context.statement_list());
            if (context.K_ELSEIF() != null)
            {
                var expr = this.Visit(context.expr());
                var else_clause = this.Visit(context.else_clause());

                return new StringBuilder($"{Environment.NewLine}else {{{Environment.NewLine}if({expr}) {{{Environment.NewLine}{statement_list}}}{else_clause}{Environment.NewLine}}}");
            }
            else
            {
                return new StringBuilder($"{Environment.NewLine}else {{{Environment.NewLine}{statement_list}}}");
            }
        }

        public override StringBuilder VisitExitwhen([NotNull] JassParser.ExitwhenContext context)
        {
            return new StringBuilder($"if ({this.Visit(context.expr())}) {{ break; }}");
        }

        public override StringBuilder VisitExpr([NotNull] JassParser.ExprContext context)
        {
            Helper.ReplaceBinaryOperator(context);

            if (Helper.IsIntegerDivision(context))
            {
                return new StringBuilder($"R2I({base.VisitExpr(context)})");
            }

            if (Helper.IsStringConcatenation(context))
            {
                return new StringBuilder($"S2S({base.VisitExpr(context)})");
            }

            // Optional
            if (Helper.IsFourccConcatenation(context))
            {
                var expressions = context.expr();
                var fourcc1 = expressions[0]?.constant()?.int_const()?.FOURCC().Symbol.Text;
                var fourcc2 = expressions[1]?.constant()?.int_const()?.FOURCC().Symbol.Text;

                if (fourcc1 == "'÷=Å«'")
                {

                }

                // 0 and 5 are parenteses
                byte[] bytes1 = Encoding.Default.GetBytes(fourcc1);
                int num1 = ((sbyte)bytes1[1]) * 256 * 256 * 256 + ((sbyte)bytes1[2]) * 256 * 256 + ((sbyte)bytes1[3]) * 256 + ((sbyte)bytes1[4]);

                byte[] bytes2 = Encoding.Default.GetBytes(fourcc2);
                int num2 = ((sbyte)bytes2[1]) * 256 * 256 * 256 + ((sbyte)bytes2[2]) * 256 * 256 + ((sbyte)bytes2[3]) * 256 + ((sbyte)bytes2[4]);
                int num3 = num1 + num2;

                return new StringBuilder(num3.ToString());
            }

            return base.VisitExpr(context);
        }

        public override StringBuilder VisitFile([NotNull] JassParser.FileContext context)
        {
            return base.VisitFile(context);
        }

        public override StringBuilder VisitFunc([NotNull] JassParser.FuncContext context)
        {
            Helper.FillLocalTypes(context);

            var func_declr = this.Visit(context.func_declr());
            var local_var_list = this.Visit(context.local_var_list());
            var statement_list = this.Visit(context.statement_list());

            return new StringBuilder($"function {func_declr}{local_var_list}{statement_list}}}{Environment.NewLine}");
        }

        public override StringBuilder VisitFunc_call([NotNull] JassParser.Func_callContext context)
        {
            return base.VisitFunc_call(context);
        }

        public override StringBuilder VisitFunc_declr([NotNull] JassParser.Func_declrContext context)
        {
            string key = context.id().GetText();
            if (!Helper.functionTypes.ContainsKey(key))
            {
                Helper.functionTypes.Add(key, context.type()?.GetText());
            }

            return new StringBuilder($"{context.id().GetText()}({this.Visit(context.param_list())}) {{{Environment.NewLine}");
        }

        public override StringBuilder VisitFunc_ref([NotNull] JassParser.Func_refContext context)
        {
            return new StringBuilder($"{context.id().GetText()}");
        }

        public override StringBuilder VisitGlobals([NotNull] JassParser.GlobalsContext context)
        {
            return this.Visit(context.global_var_list());
        }

        public override StringBuilder VisitGlobal_var_list([NotNull] JassParser.Global_var_listContext context)
        {
            Helper.FillGlobalTypes(context);

            return base.VisitGlobal_var_list(context);
        }

        public override StringBuilder VisitGlobal_var_declr([NotNull] Global_var_declrContext context)
        {
            if (context.K_CONSTANT() != null)
            {
                context.children.RemoveAt(0);
            }

            return new StringBuilder($"{base.VisitGlobal_var_declr(context)}{Environment.NewLine}");
        }

        public override StringBuilder VisitIfthenelse([NotNull] JassParser.IfthenelseContext context)
        {
            return new StringBuilder($"if ({this.Visit(context.expr())}) {{{Environment.NewLine}{this.Visit(context.statement_list())}}}{this.Visit(context.else_clause())}");
        }

        public override StringBuilder VisitInt_const([NotNull] JassParser.Int_constContext context)
        {
            ITerminalNode hex = context.HEX();
            if (hex != null)
            {
                return new StringBuilder($"{Helper.HexToDecimal(hex.Symbol.Text)}");
            }

            return base.VisitInt_const(context);
        }

        public override StringBuilder VisitLocal_var_list([NotNull] JassParser.Local_var_listContext context)
        {
            return base.VisitLocal_var_list(context);
        }

        public override StringBuilder VisitLocal_var_declr([NotNull] JassParser.Local_var_declrContext context)
        {
            // Remove local keyword
            context.children?.RemoveAt(0);

            return new StringBuilder($"{base.VisitLocal_var_declr(context)}{Environment.NewLine}");
        }

        public override StringBuilder VisitLoop([NotNull] JassParser.LoopContext context)
        {
            return new StringBuilder($"do {{{Environment.NewLine}{this.Visit(context.statement_list())}}} while(true)");
        }

        public override StringBuilder VisitNative_func([NotNull] JassParser.Native_funcContext context)
        {
            return new StringBuilder($"function {this.Visit(context.func_declr())}}}");
        }

        public override StringBuilder VisitParam_list([NotNull] JassParser.Param_listContext context)
        {
            return this.VisitChildrens(context.id(), ",");
        }

        public override StringBuilder VisitParens([NotNull] JassParser.ParensContext context)
        {
            return base.VisitParens(context);
        }

        public override StringBuilder VisitReturn_stat([NotNull] JassParser.Return_statContext context)
        {
            return this.VisitChildrens(context.children, " ");
        }

        public override StringBuilder VisitSet([NotNull] JassParser.SetContext context)
        {
            // Remove set keyword
            context.children?.RemoveAt(0);

            return base.VisitSet(context);
        }

        public override StringBuilder VisitStatement([NotNull] JassParser.StatementContext context)
        {
            return new StringBuilder($"{base.VisitStatement(context)}{Environment.NewLine}");
        }

        public override StringBuilder VisitStatement_list([NotNull] JassParser.Statement_listContext context)
        {
            return base.VisitStatement_list(context);
        }

        public override StringBuilder VisitType([NotNull] JassParser.TypeContext context)
        {
            return new StringBuilder("var ");
        }

        public override StringBuilder VisitTypedef([NotNull] JassParser.TypedefContext context)
        {
            return new StringBuilder(string.Empty);
        }

        public override StringBuilder VisitVar_declr([NotNull] JassParser.Var_declrContext context)
        {
            if (context.K_ARRAY() != null)
            {
                // Remove array keyword
                context.children?.RemoveAt(1);

                return new StringBuilder($"{base.VisitVar_declr(context)} = [];{Environment.NewLine}");
            }

            return new StringBuilder($"{base.VisitVar_declr(context)};{Environment.NewLine}");
        }

        public override StringBuilder VisitStringConst([NotNull] StringConstContext context)
        {
            var stringConst = base.VisitStringConst(context);

            // JS does not allow lune breaks in string
            Regex regex = new Regex("[\r\n]");
            if (regex.IsMatch(stringConst.ToString()))
            {
                return new StringBuilder(regex.Replace(stringConst.ToString(), string.Empty));
            }

            return stringConst;
        }

        public override StringBuilder VisitId([NotNull] IdContext context)
        {
            var id = base.VisitId(context);

            return Helper.ReplaceInvalidVariableName(id);
        }

        #endregion
    }
}
