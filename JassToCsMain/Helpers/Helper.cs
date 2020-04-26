using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using static JassParser;

namespace JassToCsMain
{
    public static class Helper
    {
        public static NameGenerator NameGenerator = new NameGenerator(3);

        public static Dictionary<string, string> FunctionTypeByName = new Dictionary<string, string>();

        public static Dictionary<string, string> GlobalVariableTypeByName = new Dictionary<string, string>();

        public static Dictionary<string, Dictionary<string, string>> LocalVariableTypeByName = new Dictionary<string, Dictionary<string, string>>();

        public static string Parse(string path)
        {
            FileContext tree;
            using (new TimeTracker("parsing"))
            {
                ICharStream charStream = CharStreams.fromPath(path, Encoding.Default);

                var lexer = new JassLexer(charStream);
                var tokens = new CommonTokenStream(lexer);
                var parser = new JassParser(tokens);
                parser.BuildParseTree = true;

                tree = parser.file();
            }

            string content;
            using (new TimeTracker("visiting"))
            {
                var visitor = new JassVisitor();
                content = visitor.Visit(tree).ToString();
            }

            return content;
        }

        public static StringBuilder ReplaceInvalidVariableName(StringBuilder id)
        {
            List<string> reservedKeywords = new List<string>()
            {
                "do",
                "in",
                "this",
                "class"
            };

            var reservedKeyword = reservedKeywords.FirstOrDefault(rk => id.ToString() == rk);

            if (reservedKeyword != null)
            {
                return new StringBuilder($"{reservedKeyword}{reservedKeyword}");
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

        public static void FillGlobalTypes(GlobalVarListContext context)
        {
            var varDeclContext = context.varDeclr();

            if (varDeclContext != null)
            {
                foreach (var varDecl in varDeclContext)
                {
                    var type = varDecl.type().GetText();
                    var name = varDecl.id().ID().Symbol.Text;

                    if (!GlobalVariableTypeByName.ContainsKey(name))
                    {
                        GlobalVariableTypeByName.Add(name, type);
                    }
                }
            }
            else
            {
                var constDeclContext = context.constDeclr();
                ITerminalNode[] nameTokens = context.GetTokens(JassLexer.ID);

                if (constDeclContext.Length != nameTokens.Length) { throw new Exception(); }

                for (int i = 0; i < constDeclContext.Length; i++)
                {
                    var type = constDeclContext[i].type().GetText();
                    var name = nameTokens[i].Symbol.Text;

                    GlobalVariableTypeByName.Add(name, type);
                }
            }
        }

        public static void FillLocalTypes(FuncContext context)
        {
            var funcName = context.funcDeclr().id().GetText();
            if (LocalVariableTypeByName.ContainsKey(funcName))
            {
                return;
            }

            LocalVariableTypeByName.Add(funcName, new Dictionary<string, string>());

            var localVarDeclContext = context.localVarList()?.localVarDeclr();

            if (localVarDeclContext != null && localVarDeclContext.Length > 0)
            {
                // Fill function body variables
                foreach (var localVarDecl in localVarDeclContext)
                {
                    var varDeclContext = localVarDecl.varDeclr();

                    var type = varDeclContext.type().GetText();
                    var name = varDeclContext.id().GetText();

                    LocalVariableTypeByName[funcName].Add(name, type);
                }
            }

            var paramNamesList = context.funcDeclr()?.paramList()?.id();

            if (paramNamesList != null && paramNamesList.Length > 0)
            {
                // Fill function parameters
                var paramTypesList = context.funcDeclr()?.paramList()?.type();
                for (int i = 0; i < paramNamesList.Length; i++)
                {
                    var type = paramTypesList[i].GetText();
                    var name = paramNamesList[i].GetText();

                    LocalVariableTypeByName[funcName].Add(name, type);
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

        public static bool IsFourccConcatenation(ExprContext context)
        {
            if (context.ADD() != null)
            {
                var expressions = context.expr();

                if (expressions != null && expressions.Length > 0 && IsExpressionOfType(expressions[0], "fourcc") && IsExpressionOfType(expressions[1], "fourcc"))
                {
                    return true;
                }
            }

            return false;
        }

        public static bool IsExpressionOfType(ExprContext exprContext, string exprType)
        {
            if (exprType == "integer" && exprContext?.constant()?.int_const() != null)
            {
                return true;
            }

            if (exprType == "fourcc" && exprContext?.constant()?.int_const()?.FOURCC() != null)
            {
                return true;
            }

            if (exprType == "string" && exprContext?.constant()?.stringConst() != null)
            {
                return true;
            }

            // Not constant value, try to find type in local or global context
            string objectName = exprContext.id()?.GetText();
            if (objectName != null)
            {
                var localFuncName = GetParentContext<FuncContext>(exprContext)?.funcDeclr()?.GetToken(JassLexer.ID, 0)?.GetText();
                return GetValueOrDefault(GlobalVariableTypeByName, objectName) == exprType || GetValueOrDefault(GetValueOrDefault(LocalVariableTypeByName, localFuncName), objectName) == exprType;
            }

            // If expression is function call, get func type
            objectName = exprContext.func_call()?.id()?.GetText();
            if (objectName != null)
            {
                return GetValueOrDefault(FunctionTypeByName, objectName) == exprType;
            }

            // If expession is array. get its type
            objectName = exprContext.array_ref()?.id()?.GetText();
            if (objectName != null)
            {
                var localFuncName = GetParentContext<FuncContext>(exprContext)?.funcDeclr()?.GetToken(JassLexer.ID, 0)?.GetText();
                return GetValueOrDefault(GlobalVariableTypeByName, objectName) == exprType || GetValueOrDefault(GetValueOrDefault(LocalVariableTypeByName, localFuncName), objectName) == exprType;
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
