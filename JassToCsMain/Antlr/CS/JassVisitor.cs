//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from Jass.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419

using Antlr4.Runtime.Misc;
using Antlr4.Runtime.Tree;
using IToken = Antlr4.Runtime.IToken;

/// <summary>
/// This interface defines a complete generic visitor for a parse tree produced
/// by <see cref="JassParser"/>.
/// </summary>
/// <typeparam name="Result">The return type of the visit operation.</typeparam>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public interface IJassVisitor<Result> : IParseTreeVisitor<Result> {
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.file"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFile([NotNull] JassParser.FileContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.declr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDeclr([NotNull] JassParser.DeclrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.typedef"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitTypedef([NotNull] JassParser.TypedefContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.globals"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGlobals([NotNull] JassParser.GlobalsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.global_var_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGlobal_var_list([NotNull] JassParser.Global_var_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.global_var_declr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitGlobal_var_declr([NotNull] JassParser.Global_var_declrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.native_func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitNative_func([NotNull] JassParser.Native_funcContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.func_declr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_declr([NotNull] JassParser.Func_declrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.param_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParam_list([NotNull] JassParser.Param_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.func"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc([NotNull] JassParser.FuncContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.local_var_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocal_var_list([NotNull] JassParser.Local_var_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.local_var_declr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLocal_var_declr([NotNull] JassParser.Local_var_declrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.var_declr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitVar_declr([NotNull] JassParser.Var_declrContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.statement_list"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement_list([NotNull] JassParser.Statement_listContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.statement"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStatement([NotNull] JassParser.StatementContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.set"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitSet([NotNull] JassParser.SetContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitCall([NotNull] JassParser.CallContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.args"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArgs([NotNull] JassParser.ArgsContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.ifthenelse"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitIfthenelse([NotNull] JassParser.IfthenelseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.else_clause"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitElse_clause([NotNull] JassParser.Else_clauseContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.loop"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitLoop([NotNull] JassParser.LoopContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.exitwhen"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExitwhen([NotNull] JassParser.ExitwhenContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.return_stat"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitReturn_stat([NotNull] JassParser.Return_statContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.debug"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDebug([NotNull] JassParser.DebugContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.expr"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitExpr([NotNull] JassParser.ExprContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.func_call"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_call([NotNull] JassParser.Func_callContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.array_ref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitArray_ref([NotNull] JassParser.Array_refContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.func_ref"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitFunc_ref([NotNull] JassParser.Func_refContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.constant"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitConstant([NotNull] JassParser.ConstantContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.int_const"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitInt_const([NotNull] JassParser.Int_constContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.decimal"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitDecimal([NotNull] JassParser.DecimalContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.hex"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitHex([NotNull] JassParser.HexContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.parens"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitParens([NotNull] JassParser.ParensContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.boolConst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitBoolConst([NotNull] JassParser.BoolConstContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.stringConst"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitStringConst([NotNull] JassParser.StringConstContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.type"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitType([NotNull] JassParser.TypeContext context);
	/// <summary>
	/// Visit a parse tree produced by <see cref="JassParser.id"/>.
	/// </summary>
	/// <param name="context">The parse tree.</param>
	/// <return>The visitor result.</return>
	Result VisitId([NotNull] JassParser.IdContext context);
}