using Ninject;
using System.IO;

namespace JassToCsMain
{
    public class Program
    {
        public static void Main(string[] args)
        {
            string basePath = @"F:\JassToCsParser\JassToCsMain\JassToCsMain\War3Map";

            //File.WriteAllText($@"{basePath}\common.js", Helper.Parse($@"{basePath}\common.j"));

            //File.WriteAllText($@"{basePath}\blizzard.js", Helper.Parse($@"{basePath}\blizzard.j"));

            //string baseJassPath = @"F:\JASS_TO_JS_PARSER\war3map\Dacia_Orpg_v1.38D[SPMOD-0.9]";
            string baseJassPath = @"F:\JassToCsMain\JASS_TO_JS_PARSER\war3map\Dunia Impian RPG S1 v1.2c_ENG_Fix";

            IKernel kernel = GetKernel();

            string parsed = kernel.Get<Parser>().Parse($@"{baseJassPath}\war3map.j");
            File.WriteAllText($@"{baseJassPath}\war3map.js", parsed);

            //Test();
        }

        public static IKernel GetKernel()
        {
            var kernel = new StandardKernel();
            kernel.Bind<Parser>().ToSelf().InSingletonScope();
            kernel.Bind<JassVisitor>().ToSelf().InSingletonScope();
            kernel.Bind<Helper>().ToSelf().InSingletonScope();
            kernel.Bind<FuncHelper>().ToSelf().InSingletonScope();

            return kernel;
        }

        public static void Test()
        {
            string baseWar3mapPath = @"F:\JassToCsMain\JASS_TO_JS_PARSER\war3map";
            string baseTestPath = @"F:\JassToCsMain\JASS_TO_JS_PARSER\test";
            string[] subdirectoryPathList = Directory.GetDirectories(baseWar3mapPath);

            foreach (string subdirectoryPath in subdirectoryPathList)
            {
                string subdirectoryName = subdirectoryPath.Remove(0, baseWar3mapPath.Length);
                string fileName = subdirectoryPath + "\\war3map.j";
                string content = new Parser().Parse(fileName);

                string baseTestFilePath = baseTestPath + subdirectoryName + ".js";
                File.WriteAllText(baseTestFilePath, content);
            }
        }
    }
}
