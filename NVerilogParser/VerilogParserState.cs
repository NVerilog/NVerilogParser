using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;

namespace NVerilogParser
{
    public class VerilogParserState<TToken> : GlobalState<TToken> where TToken : IToken
    {
        public VerilogSymbolTable<TToken> SymbolTable { get; set; } = new VerilogSymbolTable<TToken>(new Scope<TToken>(null));
    }
}
