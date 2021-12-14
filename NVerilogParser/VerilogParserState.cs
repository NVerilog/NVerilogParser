using CFGToolkit.ParserCombinator;

namespace NVerilogParser
{
    public class VerilogParserState : GlobalState<CharToken>
    {
        public SymbolTable VerilogSymbolTable { get; } = new SymbolTable();
    }
}
