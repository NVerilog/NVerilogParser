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
    public class VAPPTests
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
            IncludeMacro.Provider = (f) => GetTextFromFile(@"C:\dev\repos\VAPP\include", f);

            var parser = new VerilogParser();
            string txt = GetTextFromFile(@"C:\dev\repos\VAPP\examples", name);

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
            new object[] { @"bsim3_ring_oscillator\bsim3.va"},
            new object[] { @"bsim4_iv_curves\bsim4_vappmod.va"},
            new object[] { @"bsim6_iv_curves\bsim6.1.1_vappmod.va"},
            new object[] { @"mvs1_inverter_transient\mvs_si_1_1_0_vappmod.va"},
            new object[] { @"vbic_diffpair_ac\vbic1.2_vappmod.va" },
            new object[] { @"r3_self-heating_transient\r3_vappmod.va" },
            new object[] { @"purdue_ncfet_homotopy\mvs_5t_mod_vappmod.va" },
            new object[] { @"purdue_ncfet_homotopy\neg_cap_3t_vappmod.va" }
        };
    }
}
