using CFGToolkit.AST;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;
using NPreprocessor.Output;
using System.Collections.Generic;

namespace NVerilogParser
{
    public class VerilogParserResult
    {
        public VerilogParserResult(
            IUnionResult<CharToken> parseResult, 
            SyntaxNode concreteSyntaxTree, 
            string originalText, 
            string fullText, 
            string parsableText,
            List<CommentBlock> comments,
            bool isAmbiguous,
            bool isEmptyMatch)
        {
            ParseResult = parseResult ?? throw new System.ArgumentNullException(nameof(parseResult));
            ConcreteSyntaxTree = concreteSyntaxTree;
            OriginalText = originalText;
            FullText = fullText;
            ParsableText = parsableText;
            Comments = comments;
            IsAmbiguous = isAmbiguous;
            IsEmptyMatch = isEmptyMatch;
            GlobalState = parseResult.GlobalState;
        }

        protected IUnionResult<CharToken> ParseResult { get; private set; }

        public SyntaxNode ConcreteSyntaxTree { get; private set; }

        public IGlobalState<CharToken> GlobalState { get; private set; }

        public string OriginalText { get; private set; }

        public string FullText { get; private set; }

        public string ParsableText { get; private set; }

        public List<CommentBlock> Comments { get; private set; }

        public bool IsSuccessful => ParseResult.IsSuccessful;

        public bool IsAmbiguous { get; private set; }

        public bool IsEmptyMatch { get; private set; }

        public bool EmptyMatch { get; private set; }
    }
}
