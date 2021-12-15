using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.Values;
using CFGToolkit.Parsers.VerilogAMS;
using NVerilogParser.AST;
using System;
using System.Text.RegularExpressions;

namespace NVerilogParser
{
    public class VerilogParser
    {
        public IUnionResult<CharToken> TryParse(string txt)
        {
            return TryParse(Parsers.source_text.Value.End(), txt);
        }

        public IUnionResult<CharToken> TryParse(IParser<CharToken, SyntaxNode> parser, string txt)
        {
            var preprocessor = new Preprocessor.Preprocessor();
            var prepResult = preprocessor.DoPreprocessing(txt);

            var lexer = new Lexer.CharLexer();
            var tokens = lexer.GetTokens(prepResult.Text);

            var state = new VerilogParserState();
            state.BeforeParseActions = VerilogParserActions.BeforeActions;
            state.AfterParseActions = VerilogParserActions.AfterActions;

            HackOrderOfDefinitions(state.VerilogSymbolTable, prepResult.Text);

            var result = parser.TryParse(tokens, state);
            return result;
        }

        private void HackOrderOfDefinitions(SymbolTable verilogSymbolTable, string txt)
        {
            var modules = Regex.Matches(txt, @"(^|\b)module\s+(\w+)");

            foreach (Match module in modules)
            {
                if (module.Success)
                {
                    verilogSymbolTable.Register(module.Groups[2].Value, "module_identifier", module.Index, SymbolEntryUseType.Definition);
                }
            }

            var functions = Regex.Matches(txt, @"(^|\b)function\s+(\w+)");

            foreach (Match function in functions)
            {
                if (function.Success)
                {
                    verilogSymbolTable.Register(function.Groups[2].Value, "function_identifier", function.Index, SymbolEntryUseType.Definition);
                }
            }
        }
    }
}
