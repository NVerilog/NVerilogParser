using System.Collections.Generic;
using Xunit;

namespace NVerilogParser.Tests
{
    public class PyverilogTests : BaseTests
    {
        protected override string IncludePath => @"C:\dev\repos\Pyverilog-develop\verilogcode";

        protected override string BasePath => @"C:\dev\repos\Pyverilog-develop\verilogcode";

        [Theory]
        [MemberData(nameof(Data))]
        public void ParseAndCheckResult(string testPath)
        {
            Check(testPath);
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
