using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;

namespace NVerilogParser
{
    public class VerilogParserState<TToken> : GlobalState<TToken> where TToken : IToken
    {
        public SymbolTable VerilogSymbolTable { get; } = new SymbolTable();
    }
}
