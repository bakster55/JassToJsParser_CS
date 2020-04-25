using NUnit.Framework;

namespace JassToJsMain.UnitTest.Globals
{
    [TestFixture]
    public class GlobalsTest : TestBase
    {
        protected override string FolderName => "Globals";

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
