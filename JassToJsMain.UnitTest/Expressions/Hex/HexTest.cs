using NUnit.Framework;

namespace JassToJsMain.UnitTest.Expressions.Hex
{
    [TestFixture]
    public class HexTest : TestBase
    {
        protected override string FolderName => "Expressions\\Hex";

        [Test]
        public void Test1()
        {
            base.Execute();
        }
    }
}
