using NPreprocessor.Output;
using System.Collections.Generic;

namespace NVerilogParser.Preprocessor
{
    public class PreprocessorResult
    {
        public string ParsableText { get; set; }

        public string FullText { get; set; }

        public List<Directive> Directives { get; set; }

        public List<CommentBlock> Comments { get; set; }
    }
}
