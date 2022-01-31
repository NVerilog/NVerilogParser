using CFGToolkit.AST;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Generic;

namespace NVerilogParser
{
    public partial class Parsers
    {
        public static Func<bool, bool, string, (string valueParserName, object value)[], SyntaxNode> CreateSyntaxNode = (nodeTokenize, tokenTokenize, name, args) =>
        {
            for (var i = 0; i < args.Length; i++)
            {
                if (args[i].value is IOption<object> c)
                {
                    args[i].value = CreateOption(c.GetOrDefault());
                }
            }
            return CreateNode(name, nodeTokenize, tokenTokenize, args);
        };

        public static SyntaxNode CreateNode(string name, bool nodeTokenize, bool tokenTokenize, (string valueParserName, object value)[] args)
        {
            var node = new SyntaxNode(name);

            node.Attributes["nodeTokenize"] = nodeTokenize.ToString().ToLower();
            node.Attributes["tokenTokenize"] = tokenTokenize.ToString().ToLower();

            foreach (var item in args)
            {
                var child = item.value;

                if (child is string @string && !string.IsNullOrEmpty(@string))
                {
                    node.Children.Add(new SyntaxToken { Value = @string, Name = item.valueParserName });
                }
                else if (child is char c)
                {
                    node.Children.Add(new SyntaxToken { Value = c.ToString(), Name = item.valueParserName });
                }
                else if (child is SyntaxNode a)
                {
                    node.Children.Add(a);
                }
                else if (child is IEnumerable<ISyntaxElement> e)
                {
                    var many = new SyntaxNodeMany(item.valueParserName, e);
                    node.Children.Add(many);
                }
                else if (child is SyntaxNodeOption opt)
                {
                    opt.Name = item.valueParserName;
                    node.Children.Add(opt);
                }
            }
            return node;
        }

        public static object CreateOption(object inside)
        {
            if (inside is ISyntaxElement element)
            {
                return new SyntaxNodeOption { Inside = element };
            }

            if (inside is string text)
            {
                return new SyntaxNodeOption { Inside = new SyntaxToken() { Value = text } };
            }

            if (inside is char c)
            {
                return new SyntaxNodeOption { Inside = new SyntaxToken() { Value = c.ToString() } };
            }

            return null;
        }
    }
}
