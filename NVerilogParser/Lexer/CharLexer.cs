using CFGToolkit.ParserCombinator.Input;
using NPreprocessor.Input;
using System;
using System.Collections.Generic;

namespace NVerilogParser.Lexer
{
    public class CharLexer
    {
        public List<CharToken> GetTokens(string text)
        {
            TextReader txtReader = new TextReader(text, Environment.NewLine);
            var tokens = new List<CharToken>();
            foreach (var logicalLine in txtReader.LogicalLines)
            {
                if (logicalLine.Lines[0].Text.StartsWith('`'))
                {
                    continue;
                }

                foreach (var line in logicalLine.Lines)
                {
                    for (var i = 0; i < line.Text.Length; i++)
                    {
                        tokens.Add(new CharToken() { Position = i, Value = line.Text[i], Line = line.LineNumber });
                    }

                    if (line.Ending.Length == 2)
                    {
                        tokens.Add(new CharToken() { Position = line.Text.Length, Value = line.Ending[0], Line = line.LineNumber });
                        tokens.Add(new CharToken() { Position = line.Text.Length + 1, Value = line.Ending[1], Line = line.LineNumber });
                    }
                    else
                    {
                        if (line.Ending.Length == 1)
                        {
                            tokens.Add(new CharToken() { Position = line.Text.Length, Value = line.Ending[0], Line = line.LineNumber });
                        }
                    }
                }
            }

            return tokens;
        }
    }
}
