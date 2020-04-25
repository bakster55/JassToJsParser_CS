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
    }
}
