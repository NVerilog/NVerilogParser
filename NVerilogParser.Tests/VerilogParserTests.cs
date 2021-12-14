using CFGToolkit.ParserCombinator;
using CFGToolkit.Parsers.VerilogAMS;
using NPreprocessor.Macros;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NVerilogParser.Tests
{
    public class VerilogParserTests
    {
        HttpClient client = new HttpClient();

        public string GetTextFromUrl(string url)
        {
            return client.GetStringAsync(url).Result;
        }

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string name)
        {
            IncludeMacro.Provider = (f) => GetTextFromFile(@"C:\dev\repos\verilog-parser-master\tests", f);

            var parser = new VerilogParser();
            string txt = GetTextFromFile(@"C:\dev\repos\verilog-parser-master\tests", name);

            var timeout = 1000 * 60 * 10;

            IUnionResult<CharToken> results = null;

            var task = new Task(() => { results = parser.TryParse(txt); });
            task.Start();
            var result = Task.WaitAll(new[] { task }, timeout);
            Assert.True(result, txt);

            var state = results.State;
            if (!results.WasSuccessful)
            {
                var raw = string.Join(string.Empty, results.Input.Source.Select(s => s.Value));

                var nonConsumed = results.Input.Source.Skip(results.State.LastConsumedPosition + 1);
                string ctxt = string.Join(string.Empty, nonConsumed.Select(s => s.Value));
                Assert.True(false, ctxt + "\r\n==\r\n" + txt);
            }

            Assert.True(results.WasSuccessful, txt);
            Assert.True(results.Values.Count == 1, txt);
            Assert.False(results.Values[0].EmptyMatch);
        }

        private string GetTextFromFile(string basePath, string fileName)
        {
            return File.ReadAllText(@$"{basePath}\{fileName}");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] { @"attributes.v"},
            new object[] { @"casez.v"},
            new object[] { @"cd-missed.v"},
            new object[] { @"expression_tostring.v"},
            new object[] { @"forever-disable.v" },
            new object[] { @"functions.v" },
            new object[] { @"generate.v" },
            new object[] { @"ifdef-1.v" },
            new object[] { @"ifdef-2.v" },
            new object[] { @"inc-2.v" },
            new object[] { @"loops.v" },
            new object[] { @"macros.v" },
            new object[] { @"mod-param-dec.v" },
            new object[] { @"module-instance.v" },
            new object[] { @"net_type_directive.v" },
            new object[] { @"operators.v" },
            new object[] { @"primitives.v" },
            new object[] { @"primitives2.v" },
            new object[] { @"reg-data-types.v" },
            new object[] { @"simple_task.v" },
            new object[] { @"std-2.6.2.v" },
            new object[] { @"std-3.10.3.1.1-array-declaration.v" },
            new object[] { @"std-3.11.1-parameters.v" },
            new object[] { @"std-3.11.1-specparam.v" },
            new object[] { @"std-4.4.3-expressions.v" },
            new object[] { @"std-6.1.2-contassign.v" },
            new object[] { @"std-6.1.2-contassign2.v" },
            new object[] { @"std-7.1.6-primitives.v" },
            new object[] { @"timescale.v" },
            new object[] { @"unconnected_drive.v" },
        };
    }
}
