using System;
using System.Collections.Generic;

namespace NVerilogParser.AST
{
    public class SyntaxToken : ISyntaxElement
    {
        public string Value { get; set; }

        public string Source { get; set; }

        public string Text => Value;

        public override bool Equals(object obj)
        {
            return obj is SyntaxToken token &&
                   Value == token.Value &&
                   Source == token.Source &&
                   Text == token.Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Value, Source, Text);
        }

        public IEnumerable<SyntaxNode> GetNodes(string productionName, int max, int current)
        {
            yield break;
        }

        public IEnumerable<SyntaxNode> GetNodesByText(string txt)
        {
            yield break;
        }

        public override string ToString()
        {
            return "Token: " + Value;
        }

        IEnumerable<SyntaxToken> ISyntaxElement.GetTokens()
        {
            yield return this;
        }
    }
}
