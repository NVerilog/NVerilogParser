using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Values;
using NPreprocessor.Macros;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Xunit;

namespace NVerilogParser.Tests
{
    public class DesignersGuideTests
    {
        HttpClient client = new HttpClient();

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string name)
        {
            IncludeMacro.Provider = (f) => GetTextFromFile(@"C:\dev\repos\VerilogAMSExamples", f);

            var parser = new VerilogParser();
            string txt = GetTextFromFile(@"C:\dev\repos\VerilogAMSExamples", name);

            var timeout = 1000 * 60 * 10;

            IUnionResult<CharToken> results = null;

            var task = new Task(() => { results = parser.TryParse(txt); });
            task.Start();
            var result = Task.WaitAll(new[] { task }, timeout);
            Assert.True(result, txt);

            var state = results.GlobalState;
            if (!results.WasSuccessful)
            {
                var raw = string.Join(string.Empty, results.Input.Source.Select(s => s.Value));

                var nonConsumed = results.Input.Source.Skip(state.LastConsumedPosition + 1);
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
            new object[] { @"ch4-listing03\listing03\inverter.vams" },
            new object[] { @"ch4-listing04\listing04\clock_gen.v" },
            new object[] { @"ch4-listing05\listing05\dff.v" },
            new object[] { @"ch4-listing06\listing06\latch2.v" },
            new object[] { @"ch4-listing07\listing07\counter.v" },
            new object[] { @"ch4-listing08\listing08\freq_meas.v" },
            new object[] { @"ch4-listing09\listing09\dac.vams" },
            new object[] { @"ch4-listing10\listing10\switch.vams" },
            new object[] { @"ch4-listing11\listing11\switch.vams" },
            new object[] { @"ch4-listing12\listing12\adc.vams" },
            new object[] { @"ch4-listing13\listing13\vco.vams" },
            new object[] { @"ch4-listing14\listing14\comparator.vams" },

        };
    }
}
