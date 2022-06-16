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
                    for (var i = 0; i < line.Length; i++)
                    {
                        tokens.Add(new CharToken() { Position = position++, Value = line[i], Line = lineNumber });
                    }
                }

                txtReader.MoveNext();
            }

            return tokens;
        }
    }
}
