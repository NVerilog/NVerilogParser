using NPreprocessor;
using NPreprocessor.Macros;
using NPreprocessor.Macros.Derivations;
using System;
using System.Linq;

namespace NVerilogParser.Preprocessor
{
    public partial class Preprocessor
    {
        public Preprocessor(Func<string, string> fileProvider = null)
        {
            var macroResolver = MacroResolverFactory.CreateDefault(true, Environment.NewLine);
            macroResolver.Macros.Add(new ExpandedIfDefMacro("`ifdef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedIfNDefMacro("`ifndef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedDefineMacro("`define"));
            macroResolver.Macros.Add(new ExpandedUndefineMacro("`undef"));
            macroResolver.Macros.Add(new ExpandedIncludeMacro("`include"));

            if (fileProvider != null)
            {
                macroResolver.Macros.OfType<IncludeMacro>().Single().Provider = fileProvider;
            }
            MacroResolver = macroResolver;
        }

        public IMacroResolver MacroResolver { get; private set; }

        public PreprocessorResult DoPreprocessing(string input)
        {
            var txtReader = new TextReader(input, Environment.NewLine);

            var state = new State { DefinitionPrefix = "`" };
            var result = MacroResolver.Resolve(txtReader, state);

            return new PreprocessorResult()
            {
                Text = string.Join(string.Empty, result.Blocks.Select(b => b.Value)),
                Directives = null,
            };
        }
    }
}
