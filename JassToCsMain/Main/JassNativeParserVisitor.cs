using Antlr4.Runtime.Misc;
using Ninject;
using System.Text;

namespace JassToCsMain
{
    public class JassNativeParserVisitor : JassParserVisitor
    {
        [Inject]
        public Helper Helper { get; set; }

        [Inject]
        public FuncHelper FuncHelper { get; set; }

        #region Custom code

        public override StringBuilder VisitFuncDeclr([NotNull] JassParser.FuncDeclrContext context)
        {
            FuncHelper.FillNativeFunctionType(context);

            return base.VisitFuncDeclr(context);
        }

        public override StringBuilder VisitGlobalVarList([NotNull] JassParser.GlobalVarListContext context)
        {
            Helper.FillNativeGlobalTypes(context);

            return base.VisitGlobalVarList(context);
        }

        #endregion
    }
}
