using NPreprocessor;
using NPreprocessor.Macros.Derivations;
using System;
using System.Linq;

namespace NVerilogParser.Preprocessor
{
    public partial class Preprocessor
    {
        public PreprocessorResult DoPreprocessing(string input)
        {
            var txtReader = new TextReader(input, Environment.NewLine);

            var macroResolver = MacroResolverFactory.CreateDefault(true, Environment.NewLine);
            macroResolver.Macros.Add(new ExpandedIfDefMacro("`ifdef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedIfNDefMacro("`ifndef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedDefineMacro("`define"));
            macroResolver.Macros.Add(new ExpandedUndefineMacro("`undef"));
            macroResolver.Macros.Add(new ExpandedIncludeMacro("`include"));

            var state = new State { DefinitionPrefix = "`" };
            var result = macroResolver.Resolve(txtReader, state);

            return new PreprocessorResult()
            {
                Text = string.Join(string.Empty, result.Blocks.Select(b => b.Value)),
                Directives = null,
            };
        }
    }
}
