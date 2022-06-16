using CFGToolkit.AST;
using CFGToolkit.AST.Visitors.Cases;
using CFGToolkit.AST.Visitors.Traversals;
using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using CFGToolkit.ParserCombinator.State;

namespace NVerilogParser
{
    public class VerilogParserResult
    {
        public VerilogParserResult(IUnionResult<CharToken> result)
        {
            ParseResult = result ?? throw new System.ArgumentNullException(nameof(result));
            GlobalState = result.GlobalState;
            Input = result.Input;

            Process();
        }

        protected IUnionResult<CharToken> ParseResult { get; private set; }

        public SyntaxNode Result { get; set; }

        public IGlobalState<CharToken> GlobalState { get; set; }

        public IInputStream<CharToken> Input { get; }

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

                    Result = ParseResult.Values[0].Value as SyntaxNode;

                    if (Result != null)
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
            traversal.Accept(Result, new TreeTraversalContext());
        }
    }
}
