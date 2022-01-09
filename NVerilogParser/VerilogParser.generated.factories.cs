using CFGToolkit.AST;
using CFGToolkit.ParserCombinator.Values;
using System;
using System.Collections.Generic;

namespace NVerilogParser
{
    public partial class Parsers
    {
        public static Func<bool, string, (string valueParserName, object value)[], SyntaxNode> CreateSyntaxNode =
        (tokenize, name, args) => {
            var result = new (string valueParserName, object value)[args.Length];
            for (var i = 0; i < args.Length; i++)
            {
                var res = args[i].value;

                if (res is IOption<object> c)
                {
                    result[i].value = CreateOption(c.GetOrDefault());
                }
                else
                {
                    result[i].value = res;
                }

                result[i].valueParserName = args[i].valueParserName;
            }
            return CreateNode(name, tokenize, result);
        };

        public static SyntaxNode CreateNode(string name, bool tokenize, (string valueParserName, object value)[] args)
        {
            var node = new SyntaxNode(name);

            if (tokenize)
            {
                node.Attributes["tokenize"] = "true";
            }

            foreach (var item in args)
            {
                var child = item.value;

                if (child is string s && !string.IsNullOrEmpty(s))
                {
                    node.Children.Add(new SyntaxToken { Value = child.ToString(), Name = item.valueParserName, Parent = node });
                }
                else if (child is char c)
                {
                    node.Children.Add(new SyntaxToken { Value = c.ToString(), Name = item.valueParserName, Parent = node });
                }
                else if (child is SyntaxNode a)
                {
                    a.Parent = node;
                    node.Children.Add(a);
                }
                else if (child is IEnumerable<ISyntaxElement> e)
                {
                    node.Children.Add(new SyntaxNodeMany(item.valueParserName, e) { Parent = node });
                }
                else if (child is SyntaxNodeOption opt)
                {
                    opt.Name = item.valueParserName;
                    opt.Parent = node;
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
