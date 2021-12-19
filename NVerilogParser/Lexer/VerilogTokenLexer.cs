using CFGToolkit.Lexer;
using CFGToolkit.Lexer.Rules;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace NVerilogParser.Lexer
{
    public class VerilogTokenLexer
    {
        public List<VerilogToken> GetTokens(string txt)
        {
            var builder = new LexerGrammarBuilder<VerilogLexerState>();
            
            foreach (var keyword in VerilogKeywords.Values)
            {
                builder.AddRule(new LexerTokenRegexRule(
                    (int)VerilogTokenType.KEYWORD,
                    "Keyword: " + keyword,
                    Regex.Escape(keyword),
                    null,
                    null,
                    false,
                    false));
            }

            builder.AddRule(new LexerTokenRegexRule(
                (int)VerilogTokenType.WHITESPACE,
                "Whitespace",
                @"[\t\r\n 	]+",
                (ILexerState state, string lexem) => LexerRuleReturnDecision.IgnoreToken,
                null,
                true,
                finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.COMMA,
             "Comma",
             @",",
             null,
             null,
             true,
             finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.DOT,
             "Dot",
             @"\.",
             null,
             null,
             true,
             finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
              (int)VerilogTokenType.STRING,
            "STRING",
            "\"((?:\\\\.|[^\\\"])*)\"",
            null,
            null,
            true,
            finalRule: true));
            

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.LEFT_BRACKET,
             "(",
             @"\(",
             null,
             null,
             true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.RIGHT_BRACKET,
             ")",
             @"\)",
             null,
             null,
             true));


            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.LEFT_BRACKET_SHARP2,
             "{",
             @"{",
             null,
             null,
             true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.RIGHT_BRACKET_SHARP2,
             "}",
             @"}",
             null,
             null,
             true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.LEFT_BRACKET_SQUARE,
            "[",
            @"\[",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.RIGHT_BRACKET_SQUARE,
             "]",
             @"\]",
             null,
             null,
             true));



            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.LESS,
             "<",
             @"<",
             null,
             null,
             true));


            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.LESS_OR_EQUAL,
             "<=",
             @"<=",
             null,
             null,
             true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.GREATER,
             ">",
             @">",
             null,
             null,
             true));

            builder.AddRule(new LexerTokenRegexRule(
             (int)VerilogTokenType.GREATER_OR_EQUAL,
             ">=",
             @">=",
             null,
             null,
             true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EXCLAMATION,
            "!",
            @"!",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.TYLDA,
            "~",
            @"~",
            null,
            null,
            true));
            
            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.TYLDA_AMP,
            "~&",
            @"~&",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.TYLDA_OR,
            "~|",
            @"~\|",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.TYLDA_DASH,
            "~^",
            @"~\^",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.UNDERLINE,
            "_",
            @"_",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DASH_TYLDA,
            "^~",
            @"\^~",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.PLUS,
            "+",
            @"\+",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.MINUS,
            "-",
            @"-",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.POW,
            "POW",
            @"\*\*",
            null,
            null,
            true,
            finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.ATTRIBUTE_START,
            "ATTRIBUTE_START",
            @"\(\*(?!\))",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.ATTRIBUTE_END,
            "ATTRIBUTE_END",
            @"\*\)",
            null,
            (state, lexem) =>
            {
                return (state.ProducedTokenTypes.Last() != (int)VerilogTokenType.LEFT_BRACKET) ? LexerRuleConsumeDecision.Consume : LexerRuleConsumeDecision.Next;
            },
            true)
            { 
                Prefix = "" }
            );

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.STAR,
            "*",
            @"\*",
            null,
            null,
            true,
            finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.PROCENT,
            "%",
            @"%",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DIV,
            "/",
            @"/",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.LESS_DOUBLE,
            "<<",
            @"<<",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.LESS_TRIPLE,
            "<<<",
            @"<<<",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.GREATER_DOUBLE,
            ">>",
            @">>",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.GREATER_TRIPLE,
            ">>>",
            @">>>",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.SEMICOLON,
            ";",
            @";",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.COLON,
            ":",
            @":",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EQUAL,
            "=",
            @"=",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EQUAL_NOT,
            "!=",
            @"!=",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EQUAL_DOUBLE_NOT,
            "!==",
            @"!==",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EQUAL_DOUBLE,
            "==",
            @"==",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.EQUAL_TRIPLE,
            "===",
            @"===",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.OR_DOUBLE,
            "||",
            @"\|\|",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.OR,
            "|",
            @"\|",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.CONTRIBUTE,
            "<+",
            @"<\+",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DIGIT,
            "DIGIT",
            @"[0-9]",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.QUESTION,
            "QUESTION",
            @"\?",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.HASH,
            "HASH",
            @"#",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.SINGLE_QUOTE,
            "SINGLE_QUOTE",
            @"'",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DOUBLE_QUOTE,
            "DOUBLE_QUOTE",
            @"""",
            null,
            null,
            true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.AT,
            "AT",
            @"@",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DASH,
            "DASH",
            @"\^",
            null,
            null,
            true));
      
            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.AMP,
            "AMP",
            @"&",
            null,
            null,
            true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.AMP_DOUBLE,
            "AMP DOUBLE",
            @"&&",
            null,
            null,
            true));

            builder.AddRule(new LexerCustomRule(
            (int)VerilogTokenType.REAL_LETTER,
            "REAL_LETTER",
            (state, txt, index) =>
            {
                var rx = new Regex(@"(?<=\d*\.?\d+)[e|E][+-]?\d+");
                var m = rx.Match(txt, index);

                if (m.Success && m.Index == index)
                {
                    return new CFGToolkit.Lexer.Match { Success = true, Value = "e" };
                }

                return new CFGToolkit.Lexer.Match { Success = false};
            },
            null,
            null,
            finalRule : true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.SIMPLE_IDENTIFIER,
            "SIMPLE_IDENTIFIER",
            @"[a-zA-Z_][a-zA-Z0-9_$]*",
            null,
            (state, lexem) =>
            {
                if (state.ProducedTokenTypes.Count > 0 && (state.ProducedTokenTypes.Last() == (int)VerilogTokenType.SINGLE_QUOTE
                    || state.ProducedTokenTypes.Last() == (int)VerilogTokenType.LETTER
                    || state.ProducedTokenTypes.Last() == (int)VerilogTokenType.DIGIT))
                {
                    return LexerRuleConsumeDecision.Next;
                }
                return LexerRuleConsumeDecision.Consume;
            },
            true,
            finalRule: true));


            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.LETTER,
            "LETTER",
            @"[a-zA-Z]",
            null,
            null,
            true,
            finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.ESCAPED_IDENTIFIER,
            "ESCAPED_IDENTIFIER",
            @"\\[^ ]+",
            null,
            null,
            true,
            finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.SYSTEM_IDENTIFIER,
            "SYSTEM_IDENTIFIER",
            @"\$[a-zA-Z_][a-zA-Z0-9_$]*",
            null,
            null,
            true,
            finalRule: true));

            builder.AddRule(new LexerTokenRegexRule(
            (int)VerilogTokenType.DIRECTIVE,
            "DIRECTIVE",
            @"`.+",
            (ILexerState state, string lexem) => LexerRuleReturnDecision.IgnoreToken,
            null,
            true));


            var grammar = builder.GetGrammar();

            var lexer = new Lexer<VerilogLexerState>(grammar);

            var tokens = lexer.GetTokens(txt, new VerilogLexerState()).Select(t => new VerilogToken(t.Type, t.Lexem, t.LineNumber, t.StartColumnIndex)).ToList();

            for (var i = 0; i < tokens.Count; i++)
            {
                tokens[i].Position = i;
            }
            return tokens;
        }
    }

    public class VerilogLexerState : LexerState
    {
    }
}
