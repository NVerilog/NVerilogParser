using System.Collections.Generic;
using Xunit;

namespace NVerilogParser.Tests
{
    public class VAPPTests : BaseTests
    {
        protected override string IncludePath => @"C:\dev\repos\VAPP\include";

        protected override string BasePath => @"C:\dev\repos\VAPP\examples";

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string testPath)
        {
            Check(testPath);
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
