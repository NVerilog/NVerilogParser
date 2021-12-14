using CFGToolkit.ParserCombinator;
using NPreprocessor.Macros;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using Xunit;

namespace NVerilogParser.Tests
{
    public class OvmsTests
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
            IncludeMacro.Provider = (f) => GetTextFromFile(@"C:\dev\repos\ovams", f);

            var parser = new VerilogParser();
            string txt = GetTextFromFile(@"C:\dev\repos\ovams\testcases", name);

            txt = @"`include ""disciplines.vams""
" + txt;

            var results = parser.TryParse(txt);

            var state = results.State;
            if (!results.WasSuccessful)
            {
                string remaining = string.Join(string.Empty, results.Input.Source.Skip(results.State.LastConsumedPosition + 1).Select(s => s.Value));
                string all = string.Join(string.Empty, results.Input.Source.Select(s => s.Value));

                Assert.True(false, remaining + "\r\n==\r\n" + all);
            }


            Assert.True(results.WasSuccessful, txt);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        private string GetTextFromFile(string basePath, string fileName)
        {
            return File.ReadAllText(@$"{basePath}\{fileName}");
        }

        public static IEnumerable<object[]> Data => new List<object[]>
        {
            new object[] {"0000_identifier.vams"},
            new object[] {"0001_module.vams"},
            new object[] {"0002_real_declaration.vams"},
            new object[] {"0003_parameter.vams"},
            new object[] {"0004_initial_always.vams"},
            new object[] {"0005_constant_numbers.vams"},
            new object[] {"0006_line_directive.vams"},
            new object[] {"0007_compiler_directives.vams"},
            new object[] {"0008_net_declaration.vams"},
            new object[] {"0009_cont_delay_assignment.vams"},
            new object[] {"0009_reg_declaration.vams"},
            new object[] {"0010_preprocessor_defines.vams"},
            new object[] {"LRM VAMS-2.3, p. 005, shiftPlus5.vams"},
            new object[] {"LRM VAMS-2.3, p. 006, current_amplifier.vams"},
            new object[] {"LRM VAMS-2.3, p. 006, resistor.vams"},
            new object[] {"LRM VAMS-2.3, p. 006, voltage_amplifier.vams"},
            new object[] {"LRM VAMS-2.3, p. 030, ebersmoll.vams"},
            new object[] {"LRM VAMS-2.3, p. 036, motorckt.vams"},
            new object[] {"LRM VAMS-2.3, p. 041, loadedsrc.vams"},
            new object[] {"LRM VAMS-2.3, p. 041, top.vams"},
            new object[] {"LRM VAMS-2.3, p. 042, foo.vams"},
            new object[] {"LRM VAMS-2.3, p. 042, top.vams"},
            new object[] {"LRM VAMS-2.3, p. 063, opamp.vams"},
            new object[] {"LRM VAMS-2.3, p. 063, ramp_generator.vams"},
            new object[] {"LRM VAMS-2.3, p. 066, diode.vams"},
            new object[] {"LRM VAMS-2.3, p. 066, diode2.vams"},
            new object[] {"LRM VAMS-2.3, p. 067, vccs.vams"},
            new object[] {"LRM VAMS-2.3, p. 070, qam16.vams"},
            new object[] {"LRM VAMS-2.3, p. 071, adc.vams"},
            new object[] {"LRM VAMS-2.3, p. 072, period.vams"},
            new object[] {"LRM VAMS-2.3, p. 090, example.vams"},
            new object[] {"LRM VAMS-2.3, p. 092, diode.vams"},
            new object[] {"LRM VAMS-2.3, p. 092, relay.vams"},
            new object[] {"LRM VAMS-2.3, p. 094, dac.vams"},
            new object[] {"LRM VAMS-2.3, p. 094, resistor.vams"},
            new object[] {"LRM VAMS-2.3, p. 094, transamp.vams"},
            new object[] {"LRM VAMS-2.3, p. 095, dac8.vams"},
            new object[] {"LRM VAMS-2.3, p. 095, twocap.vams"},
            new object[] {"LRM VAMS-2.3, p. 097, amp.vams"},
            new object[] {"LRM VAMS-2.3, p. 097, capacitor.vams"},
            new object[] {"LRM VAMS-2.3, p. 097, resistor.vams"},
            new object[] {"LRM VAMS-2.3, p. 098, amp.vams"},
            new object[] {"LRM VAMS-2.3, p. 099, control_source.vams"},
            new object[] {"LRM VAMS-2.3, p. 099, value_ret.vams"},
            new object[] {"LRM VAMS-2.3, p. 100, my_conductor.vams"},
            new object[] {"LRM VAMS-2.3, p. 100, my_resistor.vams"},
            new object[] {"LRM VAMS-2.3, p. 101, relay.vams"},
            new object[] {"LRM VAMS-2.3, p. 103, opamp.vams"},
            new object[] {"LRM VAMS-2.3, p. 108, genvarexp.vams"},
            new object[] {"LRM VAMS-2.3, p. 111, bitErrorRate.vams"},
            new object[] {"LRM VAMS-2.3, p. 113, sh.vams"},
            new object[] {"LRM VAMS-2.3, p. 113, sh2.vams"},
            new object[] {"LRM VAMS-2.3, p. 114, sh.vams"},
            new object[] {"LRM VAMS-2.3, p. 115, bitStream.vams"},
            new object[] {"LRM VAMS-2.3, p. 120, sigmadelta.vams"},
            new object[] {"LRM VAMS-2.3, p. 122, examples.vams"},
            new object[] {"LRM VAMS-2.3, p. 123, m.vams"},
            new object[] {"LRM VAMS-2.3, p. 123, n.vams"},
            new object[] {"LRM VAMS-2.3, p. 124, badres.vams"},
            new object[] {"LRM VAMS-2.3, p. 125, matchedres.vams"},
            new object[] {"LRM VAMS-2.3, p. 125, parares.vams"},
            new object[] {"LRM VAMS-2.3, p. 127, semicoCMOS.vams"},
            new object[] {"LRM VAMS-2.3, p. 131, a2d_testbench_top.vams"},
            new object[] {"LRM VAMS-2.3, p. 132, adc.vams"},
            new object[] {"LRM VAMS-2.3, p. 133, adc.vams"},
            new object[] {"LRM VAMS-2.3, p. 137, adc.vams"},
            new object[] {"LRM VAMS-2.3, p. 138, rcline.vams"},
            new object[] {"LRM VAMS-2.3, p. 138, rcline2.vams"},
            new object[] {"LRM VAMS-2.3, p. 140, nlres.vams"},
            new object[] {"LRM VAMS-2.3, p. 140, nnmosfet.vams"},
            new object[] {"LRM VAMS-2.3, p. 140, pipeline_adc.vams"},
            new object[] {"LRM VAMS-2.3, p. 141, top.vams"},
            new object[] {"LRM VAMS-2.3, p. 142, samplehold.vams"},
            new object[] {"LRM VAMS-2.3, p. 149, onebit_dac.vams"},
            new object[] {"LRM VAMS-2.3, p. 150, a2d.vams"},
            new object[] {"LRM VAMS-2.3, p. 151, converter.vams"},
            new object[] {"LRM VAMS-2.3, p. 151, sampler.vams"},
            new object[] {"LRM VAMS-2.3, p. 153, sampler2.vams"},
            new object[] {"LRM VAMS-2.3, p. 153, sampler3.vams"},
            new object[] {"LRM VAMS-2.3, p. 160, a2d.vams"},
            new object[] {"LRM VAMS-2.3, p. 160, d2a.vams"},
            new object[] {"LRM VAMS-2.3, p. 161, bidir.vams"},
            new object[] {"LRM VAMS-2.3, p. 164, mixedsignal.vams"},
            new object[] {"LRM VAMS-2.3, p. 180, d2a.vams"},
            new object[] {"LRM VAMS-2.3, p. 180, d2aC.vams"},
            new object[] {"LRM VAMS-2.3, p. 181, a2d.vams"},
            new object[] {"LRM VAMS-2.3, p. 214, testbench.vams"},
            new object[] {"LRM VAMS-2.3, p. 215, monitor.vams"},
            new object[] {"LRM VAMS-2.3, p. 216, relay.vams"},
            new object[] {"LRM VAMS-2.3, p. 217, triangle.vams"},
            new object[] {"LRM VAMS-2.3, p. 218, vsine.vams"},
            new object[] {"LRM VAMS-2.3, p. 219, diode.vams"},
            new object[] {"LRM VAMS-2.3, p. 221, test_module.vams"},
            new object[] {"LRM VAMS-2.3, p. 221, test_module2.vams"},
            new object[] {"LRM VAMS-2.3, p. 223, top.vams"},
            new object[] {"LRM VAMS-2.3, p. 230, example_tb.vams"},
            new object[] {"LRM VAMS-2.3, p. 230, example_tb2.vams"},
            new object[] {"LRM VAMS-2.3, p. 233, c2e.vams"},
            new object[] {"LRM VAMS-2.3, p. 238, behavnand.vams"},
            new object[] {"LRM VAMS-2.3, p. 239, nonlin_res.vams"},
            new object[] {"LRM VAMS-2.3, p. 239, not_gate.vams"},
            new object[] {"LRM VAMS-2.3, p. 240, m1.vams"},
            new object[] {"LRM VAMS-2.3, p. 240, m2.vams"},
            new object[] {"LRM VAMS-2.3, p. 241, a2d.vams"},
            new object[] {"LRM VAMS-2.3, p. 241, m2.vams"},
            new object[] {"LRM VAMS-2.3, p. 298, resistor.vams"},
            new object[] {"LRM VAMS-2.3, p. 315, sampnhold.vams"},
            new object[] {"LRM VAMS-2.3, p. 366, diffPair.vams"},
            new object[] {"LRM VAMS-2.3, p. 366, ecpOsc.vams"},
            new object[] {"LRM VAMS-2.3, p. 366, osc.vams"},
        };
    }
}
