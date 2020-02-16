using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Antlr4.Runtime;
using System.IO;

namespace JassToCsMain
{
    class Program
    {
        static void Main(string[] args)
        {
            string basePath = @"F:\JassToCsParser\JassToCsMain\JassToCsMain\War3Map";

            //File.WriteAllText($@"{basePath}\common.js", Helper.Parse($@"{basePath}\common.j"));

            //File.WriteAllText($@"{basePath}\blizzard.js", Helper.Parse($@"{basePath}\blizzard.j"));

            string baseJassPath = @"F:\JASS_TO_JS_PARSER\war3map\Dacia_Orpg_v1.38D[SPMOD-0.9]";

            File.WriteAllText($@"{baseJassPath}\war3map.js", Helper.Parse($@"{baseJassPath}\war3map.j"));
        }
    }
}
