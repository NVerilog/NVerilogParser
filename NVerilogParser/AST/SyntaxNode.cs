using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace NVerilogParser.AST
{
    public class SyntaxNode : ISyntaxElement
    {
        public SyntaxNode(string productionName, bool tokenize, params (string valueParserName, object value)[] children)
        {
            ProductionName = productionName;
            Tokenize = tokenize;

            foreach (var item in children)
            {
                var child = item.value;

                if (child is string s && !string.IsNullOrEmpty(s))
                {
                    Children.Add(new SyntaxToken { Value = child.ToString(), Source = item.valueParserName });
                }
                else if (child is char c)
                {
                    Children.Add(new SyntaxToken { Value = c.ToString(), Source = item.valueParserName });
                }
                else if (child is SyntaxNode a)
                {
                    Children.Add(a);
                }
                else if (child is IEnumerable<ISyntaxElement> e)
                {
                    Children.Add(new SyntaxNodeMany(item.valueParserName, e));
                }
                else if (child is SyntaxNodeOption opt)
                {
                    opt.SourceName = item.valueParserName;
                    Children.Add(opt);
                }
            }
        }
        private string _text;

        public string Text
        {
            get
            {
                if (_text == null)
                {
                    var tokens = GetTokens();

                    _text = string.Join(Tokenize ? " " : string.Empty, tokens.Select(token => token.Text));
                }
                return _text;
            }
        }

        public SyntaxToken FirstToken
        {
            get
            {
                return GetTokens().FirstOrDefault();
            }
        }
        public SyntaxToken LastToken
        {
            get
            {
                return GetTokens().LastOrDefault();
            }
        }

        public IEnumerable<SyntaxToken> GetTokens()
        {
            if (Children.Count == 0) yield break;

            foreach (var child in Children)
            {
                foreach (var token in child.GetTokens())
                {
                    yield return token;
                }
            }

            yield break;
        }

        public IEnumerable<SyntaxNode> GetNodes(string productionName, int maxDepth, int current)
        {
            if (ProductionName == productionName)
            {
                yield return this;
                yield break;
            }

            if (maxDepth < current) { yield break; }

            foreach (var child in Children)
            {
                foreach (var node in child.GetNodes(productionName, maxDepth, current + 1))
                {
                    yield return node;
                }
            }

            yield break;
        }
        public IEnumerable<SyntaxNode> GetNodesByText(string text)
        {
            if (Text == text)
            {
                yield return this;
            }

            foreach (var child in Children)
            {
                foreach (var node in child.GetNodesByText(text))
                {
                    yield return node;
                }
            }

            yield break;
        }

        public string ProductionName
        {
            get; set;
        }

        public bool Tokenize { get; }

        public List<ISyntaxElement> Children { get; set; } = new List<ISyntaxElement>();

        public override string ToString()
        {
            return "SyntaxNode (" + ProductionName + "):" + Text;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Text, FirstToken, LastToken, ProductionName, Tokenize, Children);
        }

        public override bool Equals(object obj)
        {
            return obj is SyntaxNode node &&
                   Text == node.Text &&
                   (FirstToken == null && node.FirstToken == null || FirstToken.Equals(node.FirstToken)) &&
                   (LastToken == null && node.LastToken == null || LastToken.Equals(node.LastToken)) &&
                   ProductionName == node.ProductionName &&
                   Tokenize == node.Tokenize &&
                   Compare(Children, node.Children);
        }
        private bool Compare(List<ISyntaxElement> repeated1, List<ISyntaxElement> repeated2)
        {
            if (repeated1.Count != repeated2.Count)
            {
                return false;
            }

            for (var i = 0; i < repeated1.Count; i++)
            {
                if (!repeated1[i].Equals(repeated2[i]))
                {
                    return false;
                }
            }

            return true;
        }
    }
}
