using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using NPreprocessor;
using System;
using System.Collections.Generic;

namespace NVerilogParser.Lexer
{
    /// <summary>
    /// Some not very smart lexer
    /// </summary>
    public class CharLexer
    {
        public List<CharToken> GetTokens(string text)
        {
            ITextReader txtReader = new TextReader(text, Environment.NewLine);
            string line;
            int position = 0;
            var tokens = new List<CharToken>();
            txtReader.MoveNext();
            int lineNumber = 0;
            while (txtReader.Current != null)
            {
                lineNumber++;
                line = txtReader.Current.Remainder;

                if (line.StartsWith('`'))
                {
                    // skip directive
                }
                else
                {
                    char? prev = null;
                    for (var i = 0; i < line.Length; i++)
                    {
                        int index = i + position++;

                        if (prev != null && char.IsWhiteSpace(prev.Value) && char.IsWhiteSpace(line[i]))
                        {
                            continue;
                        }

                        tokens.Add(new CharToken() { Position = index, Value = line[i], Line = lineNumber });
                        prev = line[i];
                    }
                }

                txtReader.MoveNext();
            }

            return tokens;
        }
    }
}
