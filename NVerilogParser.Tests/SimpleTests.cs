using CFGToolkit.ParserCombinator;
using CFGToolkit.Parsers.VerilogAMS;
using Xunit;

namespace NVerilogParser.Tests
{
    public class SimpleTests
    {
        [Fact]
        public async void ModuleGates()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(@"module m1 (d); 
input d;
wire n1;

not a (n1,d);

endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void ModuleGates2()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(Parsers.n_output_gate_instance.Value, @"(n1,d);");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }


        [Fact]
        public async void Module1()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse("module m1 (input aa1, output cc2) ; endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }


        [Fact]
        public async void Conditional()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(Parsers.analog_conditional_expression.Value.Token().End(), "1 ? 3 : 4 ");

            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }


        [Fact]
        public async void Conditional2()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(Parsers.constant_conditional_expression.Value.Token().End(), "1 ? 3 : 4 ");

            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }


        [Fact]
        public async void Module2()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse("module m1 ; endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void Module3()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse("module m1 () ; endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void Module4()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse("module m1 (a, b, cd, ef) ; endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public void Binary1()
        {
            var results = Parsers.binary_number.Value.End().TryParse("16'b0000_1111_1010_0101");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void ListOfPortDeclarations()
        {
            var parser = new VerilogParser();

            var results = await parser.TryParse(Parsers.list_of_port_declarations.Value, "(input a, output b)");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public void Real()
        {
            var results = Parsers.real_number.Value.End().TryParse("1.23");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public void Const()
        {
            var results = Parsers.constant_primary.Value.End().TryParse("1");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void BinaryParameter()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse("module m1 ; parameter x = 16'b0000_1111_1010_0101;  endmodule");
            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void Always()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(@"
module initial_always ;
endmodule

");

            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void Always2()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(@"
module initial_always ;
	
    	always @(posedge x or negedge y) begin
    	end

endmodule

");

            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void AnalogExpression()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(
            @" module resistor (a, b); 
	inout a, b; 
	parameter real R = 1.0; 
	
endmodule ");

            Assert.True(results.WasSuccessful);
            Assert.True(results.Values.Count == 1);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void Comments()
        {
            var parser = new VerilogParser();
            var results = await parser.TryParse(
            @"// 
// N-bit DAC example. 
// 
module dac(out, in, clk); 

   /* Comment line 1
 Comment line 2 */

endmodule ");

            Assert.True(results.WasSuccessful);
            Assert.Single(results.Values);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void If()
        {
            var txt = @"module dac(out);
            if (3 == 4)
                if (0 == 0) 
                begin
                end
                else
                begin 

                end
            endmodule";
            var parser = new VerilogParser();
            var results = await parser.TryParse(txt);

            Assert.True(results.WasSuccessful);
            Assert.Single(results.Values);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public async void ModuleInstance()
        {
            var txt = "resistor #(.r(10K)) r1(out,gnd);";
            var parser = new VerilogParser();
            var results = await parser.TryParse(Parsers.module_instantiation.Value.End(), txt);

            Assert.True(results.WasSuccessful);
            Assert.Single(results.Values);
            Assert.False(results.Values[0].EmptyMatch);
        }

        [Fact]
        public void Operators()
        {
            var results = Parsers.analog_expression.Value.End().TryParse("1 + 3 * 3 + (1 + 4)");
            Assert.True(results.WasSuccessful);
            Assert.Single(results.Values);
            Assert.False(results.Values[0].EmptyMatch);
        }
    }
}
