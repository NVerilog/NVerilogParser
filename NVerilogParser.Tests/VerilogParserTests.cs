using System.Collections.Generic;
using Xunit;

namespace NVerilogParser.Tests
{
    public class VerilogParserTests : BaseTests
    {
        protected override string IncludePath => @"C:\dev\repos\verilog-parser-master\tests";

        protected override string BasePath => @"C:\dev\repos\verilog-parser-master\tests";

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string testPath)
        {
            Check(testPath);
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
