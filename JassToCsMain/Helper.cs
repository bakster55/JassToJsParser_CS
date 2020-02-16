using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using static JassParser;

namespace JassToCsMain
{
    public static class Helper
    {
        public static Dictionary<string, string> functionTypes = new Dictionary<string, string>();

        public static Dictionary<string, string> globalTypes = new Dictionary<string, string>();

        public static Dictionary<string, Dictionary<string, string>> localTypes = new Dictionary<string, Dictionary<string, string>>();

        public static string Parse(string path)
        {
            ICharStream charStream = CharStreams.fromPath(path);

            var lexer = new JassLexer(charStream);
            var tokens = new CommonTokenStream(lexer);
            var parser = new JassParser(tokens);
            parser.BuildParseTree = true;
            var tree = parser.file();
            var visitor = new JassVisitor();

            return visitor.Visit(tree);
        }

        public static string ReplaceInvalidVariableName(string id)
        {
            List<string> reservedKeywords = new List<string>()
            {
                "do",
                "in"
            };

            var reservedKeyword = reservedKeywords.FirstOrDefault(rk => id == rk);

            if (reservedKeyword != null)
            {
                return $"{reservedKeyword}{reservedKeyword}";
            }

            return id;
        }

        public static void ReplaceBinaryOperator(ParserRuleContext context)
        {
            Dictionary<int, string> replacableOperators = new Dictionary<int, string>()
            {
                { JassLexer.K_AND, "&&" },
                { JassLexer.K_OR, "||" },
                { JassLexer.K_NOT, "!" },
            };

            foreach (var replacableOperator in replacableOperators)
            {
                var token = context.GetToken(replacableOperator.Key, 0);

                if (token != null)
                {
                    var index = context.children.IndexOf(token);
                    context.children[index] = new TerminalNodeImpl(new CommonToken(JassLexer.ID, replacableOperator.Value));
                }
            }
        }

        public static void ReplaceHex(ParserRuleContext context)
        {
            var token = context.GetToken(JassLexer.HEX, 0);
            if (token != null && token.Symbol.Text[0] == '$')
            {
                var index = context.children.IndexOf(token);
                context.children[index] = new TerminalNodeImpl(new CommonToken(JassLexer.ID, token.Symbol.Text.Replace("$", "0x")));
            }
        }

        public static void FillGlobalTypes(Global_var_listContext context)
        {
            var varDeclContext = context.var_declr();

            if (varDeclContext != null)
            {
                foreach (var varDecl in varDeclContext)
                {
                    var type = varDecl.type().GetText();
                    var name = varDecl.id().ID().Symbol.Text;
                    globalTypes.Add(name, type);
                }
            }
            else
            {
                var globalVarDeclContext = context.global_var_declr();
                ITerminalNode[] nameTokens = context.GetTokens(JassLexer.ID);

                if (globalVarDeclContext.Length != nameTokens.Length) { throw new Exception(); }

                for (int i = 0; i < globalVarDeclContext.Length; i++)
                {
                    var globalVarDecl = globalVarDeclContext[i];
                    var nameToken = nameTokens[i];

                    globalTypes.Add(nameToken.Symbol.Text, globalVarDecl.type().GetText());
                }
            }
        }

        public static void FillLocalTypes(FuncContext context)
        {
            var funcName = context.func_declr().id().GetText();
            localTypes.Add(funcName, new Dictionary<string, string>());

            var localVarDeclContext = context.local_var_list()?.local_var_declr();

            if (localVarDeclContext != null && localVarDeclContext.Length > 0)
            {
                // Fill function body variables
                foreach (var localVarDecl in localVarDeclContext)
                {
                    var varDeclContext = localVarDecl.var_declr();

                    var type = varDeclContext.type().GetText();
                    var name = varDeclContext.id().GetText();
                    localTypes[funcName].Add(name, type);
                }
            }

            var paramNamesList = context.func_declr()?.param_list()?.id();

            if (paramNamesList != null && paramNamesList.Length > 0)
            {
                // Fill function parameters
                var paramTypesList = context.func_declr()?.param_list()?.type();
                for (int i = 0; i < paramNamesList.Length; i++)
                {
                    var paramName = paramNamesList[i].GetText();
                    var paramType = paramTypesList[i].GetText();

                    localTypes[funcName].Add(paramName, paramType);
                }
            }
        }

        public static bool IsIntegerDivision(ExprContext context)
        {
            if (context.DIV() != null)
            {
                var expressions = context.expr();

                if (expressions != null && expressions.Length > 0 && IsExpressionOfType(expressions[0], "integer") && IsExpressionOfType(expressions[1], "integer"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsStringConcatenation(ExprContext context)
        {
            if (context.ADD() != null)
            {
                var expressions = context.expr();

                if (expressions != null && expressions.Length > 0 && IsExpressionOfType(expressions[0], "string") && IsExpressionOfType(expressions[1], "string"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsExpressionOfType(ExprContext exprContext, string exprType)
        {
            string objectName = null;

            var localFuncName1 = GetParentContext<FuncContext>(exprContext)?.func_declr()?.GetToken(JassLexer.ID, 0)?.GetText();
            if (localFuncName1 == "BBx")
            {

            }

            if (exprContext?.constant()?.int_const() != null && exprType == "integer")
            {
                return true;
            }

            if (exprContext?.constant()?.stringConst() != null && exprType == "string")
            {
                return true;
            }

            objectName = exprContext.id()?.GetText();
            if (objectName != null)
            {
                var localFuncName = GetParentContext<FuncContext>(exprContext)?.func_declr()?.GetToken(JassLexer.ID, 0)?.GetText();
                return GetValueOrDefault(globalTypes, objectName) == exprType || GetValueOrDefault(GetValueOrDefault(localTypes, localFuncName), objectName) == exprType;
            }

            objectName = exprContext.func_call()?.id()?.GetText();
            if (objectName != null)
            {
                return GetValueOrDefault(functionTypes, objectName) == exprType;
            }

            objectName = exprContext.array_ref()?.id()?.GetText();
            if (objectName != null)
            {
                var localFuncName = GetParentContext<FuncContext>(exprContext)?.func_declr()?.GetToken(JassLexer.ID, 0)?.GetText();
                return GetValueOrDefault(globalTypes, objectName) == exprType || GetValueOrDefault(GetValueOrDefault(localTypes, localFuncName), objectName) == exprType;
            }

            return false;
        }

        public static T GetParentContext<T>(ParserRuleContext context) where T : ParserRuleContext
        {
            RuleContext parentContext = context;

            while (parentContext != null && parentContext.GetType() != typeof(T))
            {
                parentContext = parentContext?.Parent;
            }

            return parentContext as T;
        }

        public static TValue GetValueOrDefault<TKey, TValue>(Dictionary<TKey, TValue> dictionary, TKey key, TValue defaultValue = default(TValue))
        {
            return dictionary != null && key != null
                && dictionary.TryGetValue(key, out TValue value) ? value : defaultValue;
        }
    }
}
