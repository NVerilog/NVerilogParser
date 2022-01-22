using CFGToolkit.AST;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using NVerilogParser.Lexer;
using System;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NVerilogParser
{
    public class VerilogParser
    {
        public Preprocessor.Preprocessor Preprocessor { get; }

        public VerilogParser(Func<string, Task<string>> fileProvider = null)
        {
            Preprocessor = new Preprocessor.Preprocessor(fileProvider);
        }

        public Task<IUnionResult<CharToken>> TryParse(string txt, Action<(int, int)> progress = null)
        {
            return TryParse(Parsers.source_text.Value.End(), txt, progress);
        }

        public async Task<IUnionResult<CharToken>> TryParse(IParser<CharToken, SyntaxNode> parser, string txt, Action<(int, int)> progress = null)
        {
            var prepResult = await Preprocessor.DoPreprocessing(txt);

            var lexer = new CharLexer();
            var tokens = lexer.GetTokens(prepResult.Text);

            var state = new VerilogParserState<CharToken>();
            state.BeforeParseActions = VerilogParserActions.BeforeActions;
            state.AfterParseActions = VerilogParserActions.AfterActions;
            state.UpdateHandler = (result) => {
            
                if (result)
                {
                    progress?.Invoke((state.LastConsumedPosition, tokens.Count));
                }
            };

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
