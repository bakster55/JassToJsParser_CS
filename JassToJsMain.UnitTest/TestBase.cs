using JassToCsMain;
using Ninject;
using NUnit.Framework;
using System;
using System.IO;

namespace JassToJsMain.UnitTest
{
    public abstract class TestBase
    {
        protected abstract string FolderName { get; }

        public void Execute()
        {
            var projectBinDebugDirectoryInfo = Directory.GetParent(AppContext.BaseDirectory);
            var projectDirectoryInfo = projectBinDebugDirectoryInfo.Parent.Parent;

            var stackFrame = new System.Diagnostics.StackFrame(1, true);
            var currentMethodName = stackFrame.GetMethod().Name;
            var testDirectoryPath = Path.Combine(projectDirectoryInfo.FullName, FolderName, currentMethodName);

            var exampleFilePath = Path.Combine(testDirectoryPath, "Example.j");
            var expectedFilePath = Path.Combine(testDirectoryPath, "Expected.js");

            IKernel kernel = Program.GetKernel();
            var actualFileContent = kernel.Get<Parser>().Parse(exampleFilePath);
            var expectedFileContent = File.ReadAllText(expectedFilePath);

            Assert.AreEqual(expectedFileContent, actualFileContent);
        }
    }
}
