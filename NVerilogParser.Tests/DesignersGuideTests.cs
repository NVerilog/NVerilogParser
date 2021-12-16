using System.Collections.Generic;
using Xunit;

namespace NVerilogParser.Tests
{
    public class DesignersGuideTests : BaseTests
    {
        protected override string IncludePath => @"C:\dev\repos\VerilogAMSExamples";

        protected override string BasePath => @"C:\dev\repos\VerilogAMSExamples";

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string path)
        {
            Check(path);
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
