using NUnit.Framework;

namespace JassToJsMain.UnitTest.Expressions.Hex
{
    [TestFixture]
    public class IntegerDivision : TestBase
    {
        protected override string FolderName => "Operations\\IntegerDivision";

        [Test]
        public void Test1()
        {
            base.Execute();
        }
    }
}
