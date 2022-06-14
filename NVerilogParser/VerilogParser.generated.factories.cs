using CFGToolkit.AST;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Values;
using System.Collections.Generic;

namespace NVerilogParser
{
    public partial class Parsers
    {
        public static SyntaxNode CreateSyntaxNode(bool nodeTokenize, bool tokenTokenize, string name, (string valueParserName, IUnionResultValue<CharToken> value)[] args)
        {
            var node = new SyntaxNode(name);

            foreach (var item in args)
            {
                var child = item.value.Value;

                if (child is string @string && !string.IsNullOrEmpty(@string))
                {
                    var token = new SyntaxToken { Value = @string, Name = item.valueParserName };
                    token.Attributes["start"] = item.value.Position;
                    token.Attributes["end"] = item.value.Position + item.value.ConsumedTokens - 1;
                    node.Children.Add(token);
                }
                else if (child is char c)
                {
                    var token = new SyntaxToken { Value = c.ToString(), Name = item.valueParserName };
                    token.Attributes["start"] = item.value.Position;
                    token.Attributes["end"] = item.value.Position + 1;
                    node.Children.Add(token);
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
                    if (!opt.IsEmpty)
                    {
                        opt.Name = item.valueParserName;
                        node.Children.Add(opt.Inside);
                    }
                }
                else
                {
                    if (child is IOption<object> option && !option.IsEmpty)
                    {
                        if (option.GetOrDefault() is string text)
                        {
                            var token = new SyntaxToken { Value = text, Name = item.valueParserName };
                            token.Attributes["start"] = item.value.Position;
                            token.Attributes["end"] = item.value.Position + item.value.ConsumedTokens - 1;
                            node.Children.Add(token);
                        }

                        if (option.GetOrDefault() is char c2)
                        {
                            var token = new SyntaxToken { Value = c2.ToString(), Name = item.valueParserName };
                            token.Attributes["start"] = item.value.Position;
                            token.Attributes["end"] = item.value.Position + 1;
                            node.Children.Add(token);
                        }

                        if (option.GetOrDefault() is ISyntaxElement element)
                        {
                            node.Children.Add(element);
                        }
                    }
                }
            }
            return node;
        }
    }
}
