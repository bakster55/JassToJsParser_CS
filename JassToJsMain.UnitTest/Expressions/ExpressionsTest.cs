using NUnit.Framework;

namespace JassToJsMain.UnitTest.Expressions
{
    [TestFixture]
    public class ExpressionsTest : TestBase
    {
        protected override string FolderName => "Expressions";

        [Test]
        public void Test1()
        {
            base.Execute();
        }

        [Test]
        public void Test2()
        {
            base.Execute();
        }
    }
}
