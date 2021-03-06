//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     ANTLR Version: 4.8
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

// Generated from JassParser.g4 by ANTLR 4.8

// Unreachable code detected
#pragma warning disable 0162
// The variable '...' is assigned but its value is never used
#pragma warning disable 0219
// Missing XML comment for publicly visible type or member '...'
#pragma warning disable 1591
// Ambiguous reference in cref attribute
#pragma warning disable 419


using Antlr4.Runtime.Misc;
using IErrorNode = Antlr4.Runtime.Tree.IErrorNode;
using ITerminalNode = Antlr4.Runtime.Tree.ITerminalNode;
using IToken = Antlr4.Runtime.IToken;
using ParserRuleContext = Antlr4.Runtime.ParserRuleContext;

/// <summary>
/// This class provides an empty implementation of <see cref="IJassParserListener"/>,
/// which can be extended to create a listener which only needs to handle a subset
/// of the available methods.
/// </summary>
[System.CodeDom.Compiler.GeneratedCode("ANTLR", "4.8")]
[System.CLSCompliant(false)]
public partial class JassParserBaseListener : IJassParserListener {
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.file"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFile([NotNull] JassParser.FileContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.file"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFile([NotNull] JassParser.FileContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.declr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDeclr([NotNull] JassParser.DeclrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.declr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDeclr([NotNull] JassParser.DeclrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.typedef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterTypedef([NotNull] JassParser.TypedefContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.typedef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitTypedef([NotNull] JassParser.TypedefContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.globals"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGlobals([NotNull] JassParser.GlobalsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.globals"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGlobals([NotNull] JassParser.GlobalsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.globalVarList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterGlobalVarList([NotNull] JassParser.GlobalVarListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.globalVarList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitGlobalVarList([NotNull] JassParser.GlobalVarListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.constDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstDeclr([NotNull] JassParser.ConstDeclrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.constDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstDeclr([NotNull] JassParser.ConstDeclrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.nativeFunc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterNativeFunc([NotNull] JassParser.NativeFuncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.nativeFunc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitNativeFunc([NotNull] JassParser.NativeFuncContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.funcDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncDeclr([NotNull] JassParser.FuncDeclrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.funcDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncDeclr([NotNull] JassParser.FuncDeclrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.paramList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParamList([NotNull] JassParser.ParamListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.paramList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParamList([NotNull] JassParser.ParamListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.paramDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParamDeclr([NotNull] JassParser.ParamDeclrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.paramDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParamDeclr([NotNull] JassParser.ParamDeclrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.func"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFunc([NotNull] JassParser.FuncContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.func"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFunc([NotNull] JassParser.FuncContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.localVarList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLocalVarList([NotNull] JassParser.LocalVarListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.localVarList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLocalVarList([NotNull] JassParser.LocalVarListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.varDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterVarDeclr([NotNull] JassParser.VarDeclrContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.varDeclr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitVarDeclr([NotNull] JassParser.VarDeclrContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.statementList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatementList([NotNull] JassParser.StatementListContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.statementList"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatementList([NotNull] JassParser.StatementListContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStatement([NotNull] JassParser.StatementContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.statement"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStatement([NotNull] JassParser.StatementContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.set"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterSet([NotNull] JassParser.SetContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.set"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitSet([NotNull] JassParser.SetContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterCall([NotNull] JassParser.CallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.call"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitCall([NotNull] JassParser.CallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArgs([NotNull] JassParser.ArgsContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.args"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArgs([NotNull] JassParser.ArgsContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.ifthenelse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIfthenelse([NotNull] JassParser.IfthenelseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.ifthenelse"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIfthenelse([NotNull] JassParser.IfthenelseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.elseClause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterElseClause([NotNull] JassParser.ElseClauseContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.elseClause"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitElseClause([NotNull] JassParser.ElseClauseContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.loop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterLoop([NotNull] JassParser.LoopContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.loop"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitLoop([NotNull] JassParser.LoopContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.exitwhen"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExitwhen([NotNull] JassParser.ExitwhenContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.exitwhen"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExitwhen([NotNull] JassParser.ExitwhenContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.returnStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterReturnStat([NotNull] JassParser.ReturnStatContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.returnStat"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitReturnStat([NotNull] JassParser.ReturnStatContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.debug"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDebug([NotNull] JassParser.DebugContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.debug"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDebug([NotNull] JassParser.DebugContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterExpr([NotNull] JassParser.ExprContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.expr"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitExpr([NotNull] JassParser.ExprContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.funcCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncCall([NotNull] JassParser.FuncCallContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.funcCall"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncCall([NotNull] JassParser.FuncCallContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.arrayRef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterArrayRef([NotNull] JassParser.ArrayRefContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.arrayRef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitArrayRef([NotNull] JassParser.ArrayRefContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.funcRef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFuncRef([NotNull] JassParser.FuncRefContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.funcRef"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFuncRef([NotNull] JassParser.FuncRefContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterConstant([NotNull] JassParser.ConstantContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.constant"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitConstant([NotNull] JassParser.ConstantContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.intConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterIntConst([NotNull] JassParser.IntConstContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.intConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitIntConst([NotNull] JassParser.IntConstContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.fourcc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterFourcc([NotNull] JassParser.FourccContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.fourcc"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitFourcc([NotNull] JassParser.FourccContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.decimal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterDecimal([NotNull] JassParser.DecimalContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.decimal"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitDecimal([NotNull] JassParser.DecimalContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.hex"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterHex([NotNull] JassParser.HexContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.hex"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitHex([NotNull] JassParser.HexContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.parens"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterParens([NotNull] JassParser.ParensContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.parens"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitParens([NotNull] JassParser.ParensContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.boolConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterBoolConst([NotNull] JassParser.BoolConstContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.boolConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitBoolConst([NotNull] JassParser.BoolConstContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.stringConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterStringConst([NotNull] JassParser.StringConstContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.stringConst"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitStringConst([NotNull] JassParser.StringConstContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterType([NotNull] JassParser.TypeContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.type"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitType([NotNull] JassParser.TypeContext context) { }
	/// <summary>
	/// Enter a parse tree produced by <see cref="JassParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void EnterId([NotNull] JassParser.IdContext context) { }
	/// <summary>
	/// Exit a parse tree produced by <see cref="JassParser.id"/>.
	/// <para>The default implementation does nothing.</para>
	/// </summary>
	/// <param name="context">The parse tree.</param>
	public virtual void ExitId([NotNull] JassParser.IdContext context) { }

	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void EnterEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void ExitEveryRule([NotNull] ParserRuleContext context) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitTerminal([NotNull] ITerminalNode node) { }
	/// <inheritdoc/>
	/// <remarks>The default implementation does nothing.</remarks>
	public virtual void VisitErrorNode([NotNull] IErrorNode node) { }
}
