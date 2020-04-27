using Antlr4.Runtime;
using Antlr4.Runtime.Tree;
using Ninject;
using System;
using System.Collections.Generic;
using System.Text;
using static JassParser;

namespace JassToCsMain
{
    public class Parser
    {
        [Inject]
        public JassVisitor JassVisitor { get; set; }

        public string Parse(string path)
        {
            FileContext tree;
            using (new TimeTracker("parsing"))
            {
                ICharStream charStream = CharStreams.fromPath(path, Encoding.Default);

                var lexer = new JassLexer(charStream);
                var tokens = new CommonTokenStream(lexer);
                var parser = new JassParser(tokens);
                parser.BuildParseTree = true;

                tree = parser.file();
            }

            string content;
            using (new TimeTracker("visiting"))
            {
                content = JassVisitor.Visit(tree).ToString();
            }

            return content;
        }
    }
}
