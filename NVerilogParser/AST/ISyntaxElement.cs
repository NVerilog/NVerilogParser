using System.Collections.Generic;

namespace NVerilogParser.AST
{
    public interface ISyntaxElement
    {
        string Text { get; }

        IEnumerable<SyntaxToken> GetTokens();

        IEnumerable<SyntaxNode> GetNodes(string productionName, int maxDepth, int current);

        IEnumerable<SyntaxNode> GetNodesByText(string txt);

        bool Equals(object obj);
    }
}
