using System.Collections.Generic;
using System.Linq;

namespace NVerilogParser.AST
{
    public class SyntaxNodeMany : ISyntaxElement
    {
        public SyntaxNodeMany(string sourceName, IEnumerable<ISyntaxElement> repeated)
        {
            Repeated = new List<ISyntaxElement>(repeated) ?? throw new System.ArgumentNullException(nameof(repeated));
            SourceName = sourceName;
        }

        public List<ISyntaxElement> Repeated { get; }

        public string Text
        {
            get
            {
                return string.Join(" ", Repeated.Select(el => el.Text));
            }
        }

        public string SourceName { get; }

        public IEnumerable<SyntaxToken> GetTokens()
        {
            foreach (var item in Repeated)
            {
                foreach (var t2 in item.GetTokens())
                {
                    yield return t2;
                }
            }
            yield break;
        }

        public IEnumerable<SyntaxNode> GetNodes(string name, int max, int current)
        {
            foreach (var item in Repeated)
            {
                foreach (var node in item.GetNodes(name, max, current + 1))
                {
                    yield return node;
                }
            }
            yield break;
        }
        public override string ToString()
        {
            return $"{SourceName} -> Many inside";
        }

        public override bool Equals(object obj)
        {
            var tmp = obj is SyntaxNodeMany many &&
                   Compare(Repeated, many.Repeated) &&
                   Text == many.Text &&
                   SourceName == many.SourceName;

            return tmp;
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

        public override int GetHashCode()
        {
            return System.HashCode.Combine(Repeated, Text, SourceName);
        }

        public IEnumerable<SyntaxNode> GetNodesByText(string txt)
        {
            foreach (var item in Repeated)
            {
                foreach (var node in item.GetNodesByText(txt))
                {
                    yield return node;
                }
            }
            yield break;
        }
    }
}
