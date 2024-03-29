﻿using CFGToolkit.AST;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using NVerilogParser.Lexer;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NVerilogParser
{
    public class VerilogParser
    {
        public Preprocessor.Preprocessor Preprocessor { get; }

        public VerilogParserState<CharToken> State { get; }

        public VerilogParser(Func<string, Task<string>> fileProvider = null, Dictionary<string, string> defines = null)
        {
            Preprocessor = new Preprocessor.Preprocessor(fileProvider, defines);
            State = new VerilogParserState<CharToken>();
        }

        public Task<VerilogParserResult> TryParse(string txt, Action<(int, int)> progress = null)
        {
            return TryParse(Parsers.source_text.Value.End(), txt, progress);
        }

        public async Task<VerilogParserResult> TryParse(IParser<CharToken, SyntaxNode> parser, string txt, Action<(int, int)> progress = null)
        {
            var preprocessorResult = await Preprocessor.DoPreprocessing(txt);

            var lexer = new CharLexer();
            var tokens = lexer.GetTokens(preprocessorResult.ParsableText);

            if (Options.Cache)
            {
                State.Cache = new IUnionResult<CharToken>[tokens.Count, Parsers.MaxCached];
            }

            State.UpdateHandler = (result) =>
            {
                if (result)
                {
                    progress?.Invoke((State.LastConsumedPosition, tokens.Count));
                }
            };

            HackOrderOfDefinitions(State.SymbolTable, preprocessorResult.ParsableText);

            var result = parser.TryParse(tokens, State);

            return await VerilogParserResultFactory.Create(result, txt, preprocessorResult.FullText, preprocessorResult.ParsableText, preprocessorResult.Comments, preprocessorResult.Directives);
        }

        private void HackOrderOfDefinitions(VerilogSymbolTable<CharToken> verilogSymbolTable, string txt)
        {
            var modules = Regex.Matches(txt, @"(^|\b)module\s+(\w+)");

            foreach (Match module in modules)
            {
                if (module.Success)
                {
                    verilogSymbolTable.Root.RegisterDefinition(module.Groups[2].Value, "module_identifier", module.Index);
                }
            }

            var disciplines = Regex.Matches(txt, @"(^|\b)discipline\s+\\?(\w+)");

            foreach (Match discipline in disciplines)
            {
                if (discipline.Success)
                {
                    verilogSymbolTable.Root.RegisterDefinition(discipline.Groups[2].Value, "discipline_identifier", discipline.Index);
                }
            }

            var natures = Regex.Matches(txt, @"(^|\b)nature\s+(\w+)");
            foreach (Match nature in natures)
            {
                if (nature.Success)
                {
                    verilogSymbolTable.Root.RegisterDefinition(nature.Groups[2].Value, "nature_identifier", nature.Index);
                }
            }

            var functions = Regex.Matches(txt, @"(^|\b)function\s+(\w+)");

            foreach (Match function in functions)
            {
                if (function.Success)
                {
                    verilogSymbolTable.Root.RegisterDefinition(function.Groups[2].Value, "function_identifier", function.Index);
                }
            }
        }
    }
}
