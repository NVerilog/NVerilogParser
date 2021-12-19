using CFGToolkit.Lexer;

namespace NVerilogParser.Lexer
{
    public class VerilogToken : Token, CFGToolkit.ParserCombinator.Input.IToken
    {
        public VerilogToken(int tokenType, string lexem, int lineNumber, int startColumnIndex) : base(tokenType, lexem, lineNumber, startColumnIndex)
        {
        }

        public int Position { get; set; }

        public VerilogTokenType VerilogType => (VerilogTokenType)Type;
    }
}
