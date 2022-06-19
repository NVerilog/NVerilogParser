using CFGToolkit.AST;
using CFGToolkit.AST.Visitors.Cases;
using CFGToolkit.AST.Visitors.Traversals;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NVerilogParser
{
    public static class VerilogParserResultFactory
    {
        public static async Task<VerilogParserResult> Create(CFGToolkit.ParserCombinator.IUnionResult<CFGToolkit.ParserCombinator.Input.CharToken> result, string originalText, string fullText, string parsableText, List<NPreprocessor.Output.CommentBlock> comments, List<Preprocessor.Directive> directives)
        {
            SyntaxNode concreteSyntaxTreeRoot = null;

            if (result.IsSuccessful && result.Values?.Count == 1)
            {
                concreteSyntaxTreeRoot = result.Values[0].Value as SyntaxNode;
            }

            if (concreteSyntaxTreeRoot != null)
            {
                // set parent
                SetNodeParent(concreteSyntaxTreeRoot);
            }

            return new VerilogParserResult(result, concreteSyntaxTreeRoot, originalText, fullText, parsableText, comments, result.Values?.Count > 1, result.Values?.All(v => v.EmptyMatch) ?? false);
        }

        private static void SetNodeParent(SyntaxNode concreteSyntaxTreeRoot)
        {
            var visitor = new SetParentVisitor();
            var traversal = new PreOrderTreeTraversal<bool>(visitor);
            traversal.Accept(concreteSyntaxTreeRoot, new TreeTraversalContext());
        }
    }
}
