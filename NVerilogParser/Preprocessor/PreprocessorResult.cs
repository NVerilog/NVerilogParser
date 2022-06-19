﻿using NPreprocessor.Output;
using System.Collections.Generic;

namespace NVerilogParser.Preprocessor
{
    public class PreprocessorResult
    {
        public string Text { get; set; }

        public List<Directive> Directives { get; set; }

        public List<CommentBlock> Comments { get; set; }
    }
}
