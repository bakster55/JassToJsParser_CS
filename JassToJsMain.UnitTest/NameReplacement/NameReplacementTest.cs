using NUnit.Framework;

namespace JassToJsMain.UnitTest.NameReplacement
{
    [TestFixture]
    public class NameReplacementTest : TestBase
    {
        protected override string FolderName => "NameReplacement";

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
