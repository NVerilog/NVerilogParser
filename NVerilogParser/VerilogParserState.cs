using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;

namespace NVerilogParser
{
    public class VerilogParserState : GlobalState<CharToken>
    {
        public SymbolTable VerilogSymbolTable { get; } = new SymbolTable();
    }
}
