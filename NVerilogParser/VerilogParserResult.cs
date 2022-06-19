using CFGToolkit.AST;
using CFGToolkit.AST.Visitors.Cases;
using CFGToolkit.AST.Visitors.Traversals;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;
using NPreprocessor.Output;
using System.Collections.Generic;

namespace NVerilogParser
{
    public class VerilogParserResult
    {
        public VerilogParserResult(IUnionResult<CharToken> result)
        {
            ParseResult = result ?? throw new System.ArgumentNullException(nameof(result));
            GlobalState = result.GlobalState;

            Process();
        }

        protected IUnionResult<CharToken> ParseResult { get; private set; }

        public SyntaxNode ConcreteSyntaxTree { get; set; }

        public IGlobalState<CharToken> GlobalState { get; set; }

        public string OriginalText { get; set; }

        public string FullText { get; set; }

        public string ParsableText { get; set; }

        public List<CommentBlock> Comments { get; set; }

        public bool IsSuccessful => ParseResult.IsSuccessful;

        public bool IsAmbiguous { get; set; }

        public bool EmptyMatch { get; set; }

        private void Process()
        {
            if (ParseResult.IsSuccessful)
            {
                if (ParseResult.Values.Count == 1)
                {
                    EmptyMatch = ParseResult.Values[0].EmptyMatch;

                    ConcreteSyntaxTree = ParseResult.Values[0].Value as SyntaxNode;

                    if (ConcreteSyntaxTree != null)
                    {
                        TransformResult();
                    }
                }
                else
                {
                    IsAmbiguous = true;
                }
            }
        }

        private void TransformResult()
        {
            SetParents();
        }

        private void SetParents()
        {
            var visitor = new SetParentVisitor();
            var traversal = new PreOrderTreeTraversal<bool>(visitor);
            traversal.Accept(ConcreteSyntaxTree, new TreeTraversalContext());
        }
    }
}
