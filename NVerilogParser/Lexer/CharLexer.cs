using CFGToolkit.ParserCombinator;
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
            while (txtReader.Current != null)
            {
                line = txtReader.Current.Remainder;

                if (line.StartsWith('`'))
                {
                    // skip directive
                }
                else
                {
                    for (var i = 0; i < line.Length; i++)
                    {
                        int index = i + position++;
                        tokens.Add(new CharToken() { StartIndex = index, EndIndex = index, Value = line[i] });
                    }
                }

                txtReader.MoveNext();
            }

            return tokens;
        }
    }
}
