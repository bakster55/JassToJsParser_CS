using Antlr4.Runtime;
using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static JassParser;

namespace JassToCsMain
{
    class JassVisitor : JassBaseVisitor<string>
    {
        public override string Visit(IParseTree tree)
        {
            if (tree != null)
            {
                return tree.Accept(this);
            }

            return string.Empty;
        }

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

                //return nodes.Aggregate(separator, (accumulator, element) => accumulator + this.Visit(element));
            }

            return string.Empty;
        }

        public override string VisitChildren(IRuleNode node)
        {
            return this.Visit(node);
        }

        public override string VisitTerminal(ITerminalNode node)
        {
            return node.Symbol.Text;
        }

        public override string VisitArgs([NotNull] JassParser.ArgsContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitArray_ref([NotNull] JassParser.Array_refContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitBoolConst([NotNull] JassParser.BoolConstContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitCall([NotNull] JassParser.CallContext context)
        {
            // Remove call keyword
            context.children?.RemoveAt(0);

            return this.VisitChildrens(context.children);
        }

        public override string VisitConstant([NotNull] JassParser.ConstantContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitDebug([NotNull] JassParser.DebugContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitDeclr([NotNull] JassParser.DeclrContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitElse_clause([NotNull] JassParser.Else_clauseContext context)
        {
            if (context.K_ELSEIF() != null)
            {
                return $"\nelse {{\nif({this.VisitChildren(context.expr())}) {{\n{this.VisitChildren(context.statement_list())}}}{this.VisitChildren(context.else_clause())}\n}}";
            }
            else
            {
                return $"\nelse {{\n{this.VisitChildren(context.statement_list())}}}";
            }
        }

        public override string VisitErrorNode(IErrorNode node)
        {
            return this.Visit(node);
        }

        public override string VisitExitwhen([NotNull] JassParser.ExitwhenContext context)
        {
            return $"if ({this.VisitChildren(context.expr())}) {{ break; }}";
        }

        public override string VisitExpr([NotNull] JassParser.ExprContext context)
        {
            Helper.ReplaceInvalidVariableName(context);
            Helper.ReplaceBinaryOperator(context);

            if (Helper.IsIntegerDivision(context))
            {
                return $"R2I({this.VisitChildrens(context.children)})";
            }

            if (Helper.IsStringConcatenation(context))
            {
                return $"S2S({this.VisitChildrens(context.children)})";
            }

            return this.VisitChildrens(context.children);
        }

        public override string VisitFile([NotNull] JassParser.FileContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitFunc([NotNull] JassParser.FuncContext context)
        {
            Helper.FillLocalTypes(context);

            var result = this.VisitChildren(context.func_declr()) + this.VisitChildren(context.local_var_list()) + this.VisitChildren(context.statement_list());

            return $"function {result}\n}}\n";
        }

        public override string VisitFunc_call([NotNull] JassParser.Func_callContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitFunc_declr([NotNull] JassParser.Func_declrContext context)
        {
            Helper.functionTypes.Add(context.ID().GetText(), context.type()?.GetText());

            return $"{context.ID().GetText()}({this.VisitChildren(context.param_list())}) {{\n";
        }

        public override string VisitFunc_ref([NotNull] JassParser.Func_refContext context)
        {
            return $"{context.ID().GetText()}";
        }

        public override string VisitGlobals([NotNull] JassParser.GlobalsContext context)
        {
            return this.VisitChildren(context.global_var_list());
        }

        public override string VisitGlobal_var_list([NotNull] JassParser.Global_var_listContext context)
        {
            Helper.FillGlobalTypes(context);

            return this.VisitChildrens(context.children);
        }

        public override string VisitGlobal_var_declr([NotNull] Global_var_declrContext context)
        {
            if (context.K_CONSTANT() != null)
            {
                context.children.RemoveAt(0);
            }

            return $"{this.VisitChildrens(context.children)}\n";
        }

        public override string VisitIfthenelse([NotNull] JassParser.IfthenelseContext context)
        {
            return $"if ({this.VisitChildren(context.expr())}) {{\n{this.VisitChildren(context.statement_list())}}}{this.VisitChildren(context.else_clause())}"; ;
        }

        public override string VisitInt_const([NotNull] JassParser.Int_constContext context)
        {
            Helper.ReplaceHex(context);

            return this.VisitChildrens(context.children);
        }

        public override string VisitLocal_var_list([NotNull] JassParser.Local_var_listContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitLocal_var_declr([NotNull] JassParser.Local_var_declrContext context)
        {
            // Remove local keyword
            context.children?.RemoveAt(0);

            return $"{this.VisitChildrens(context.children)}\n";
        }

        public override string VisitLoop([NotNull] JassParser.LoopContext context)
        {
            return $"do {{\n{this.VisitChildren(context.statement_list())}}} while(true)";
        }

        public override string VisitNative_func([NotNull] JassParser.Native_funcContext context)
        {
            return $"function {this.VisitChildren(context.func_declr())}\n}}\n";
        }

        public override string VisitParam_list([NotNull] JassParser.Param_listContext context)
        {
            return this.VisitChildrens(context.ID(), ",");
        }

        public override string VisitParens([NotNull] JassParser.ParensContext context)
        {
            return this.VisitChildrens(context.children);
        }

        public override string VisitReturn_stat([NotNull] JassParser.Return_statContext context)
        {
            return this.VisitChildrens(context.children, " ");
        }

        public override string VisitSet([NotNull] JassParser.SetContext context)
        {
            // Remove set keyword
            context.children?.RemoveAt(0);

            Helper.ReplaceInvalidVariableName(context);

            return this.VisitChildrens(context.children);
        }

        public override string VisitStatement([NotNull] JassParser.StatementContext context)
        {
            return $"{this.VisitChildrens(context.children)}\n";
        }

        public override string VisitStatement_list([NotNull] JassParser.Statement_listContext context)
        {
            return this.VisitChildrens(context.children);
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
            Helper.ReplaceInvalidVariableName(context);

            if (context.K_ARRAY() != null)
            {
                // Remove array keyword
                context.children?.RemoveAt(1);

                return $"{this.VisitChildrens(context.children)} = []\n";
            }

            return $"{this.VisitChildrens(context.children)}\n";
        }
    }
}
