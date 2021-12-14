using System;
using System.Collections.Generic;

namespace NVerilogParser.AST
{
    public class SyntaxNodeOption : ISyntaxElement
    {
        public SyntaxNodeOption(object inside)
        {
            if (inside is ISyntaxElement element)
            {
                Inside = element;
            }

            if (inside is string text)
            {
                Inside = new SyntaxToken() { Value = text };
            }


            if (inside is char c)
            {
                Inside = new SyntaxToken() { Value = c.ToString() };
            }
        }

        public bool IsEmpty
        {
            get
            {
                return Inside == null;
            }
        }

        public ISyntaxElement Inside { get; }

        public override string ToString()
        {
            return "Option: " + Text;
        }

        public IEnumerable<SyntaxToken> GetTokens()
        {
            if (IsEmpty)
            {
                yield break;
            }
            else
            {
                foreach (var token in Inside.GetTokens())
                {
                    yield return token;
                }
            }
        }

        public IEnumerable<SyntaxNode> GetNodes(string name, int max, int current)
        {
            if (IsEmpty)
            {
                yield break;
            }
            else
            {
                foreach (var node in Inside.GetNodes(name, max, current + 1))
                {
                    yield return node;
                }
            }
        }

        public override bool Equals(object obj)
        {
            return obj is SyntaxNodeOption option &&
                   IsEmpty == option.IsEmpty &&
                   (Inside == null && option.Inside == null || Inside.Equals(option.Inside)) &&
                   Text == option.Text &&
                   SourceName == option.SourceName;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(IsEmpty, Inside, Text);
        }

        public IEnumerable<SyntaxNode> GetNodesByText(string txt)
        {
            if (IsEmpty)
            {
                yield break;
            }
            else
            {
                foreach (var node in Inside.GetNodesByText(txt))
                {
                    yield return node;
                }
            }
        }

        public string Text
        {
            get
            {
                if (IsEmpty)
                {
                    return "";
                }
                else
                {
                    return Inside.Text;
                }
            }
        }

        public string SourceName { get; set; }
    }
}
