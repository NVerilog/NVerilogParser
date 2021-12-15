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
    public class PyverilogTests
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
            IncludeMacro.Provider = (f) => GetTextFromFile(@"C:\dev\repos\Pyverilog-develop\verilogcode", f);

            var parser = new VerilogParser();
            string txt = GetTextFromFile(@"C:\dev\repos\Pyverilog-develop\verilogcode", name);

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
                new object[] { @"blocking.v" },
                new object[] { @"case.v" },
                new object[] { @"case_in_func.v"},
                new object[] { @"casex.v" },
                new object[] { @"count.v"},
                new object[] { @"decimal.v" },
                new object[] { @"decimal_signed.v"},
                new object[] { @"decimal_width.v" },
                new object[] { @"deepcase.v"},
                new object[] { @"delay.v" },
                new object[] { @"escape.v"},
                new object[] { @"function.v" },
                new object[] { @"generate.v"},
                new object[] { @"generate_instance.v" },
                new object[] { @"instance_array.v"},
                new object[] { @"instance_empty_params.v" },
                new object[] { @"led.v"},
                new object[] { @"led_main.v" },
                new object[] { @"partial.v"},
                new object[] { @"partselect_assign.v" },
                new object[] { @"primitive.v"},
                new object[] { @"ptr_clock_reset.v" },
                new object[] { @"ram.v"},
                new object[] { @"reset.v" },
                new object[] { @"signed_task.v"},
                new object[] { @"statemachine.v" },
                new object[] { @"supply.v"},
                new object[] { @"vectoradd.v" }

        };
    }
}
