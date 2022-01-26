using NPreprocessor;
using NPreprocessor.Macros;
using NPreprocessor.Macros.Derivations;
using NVerilogParser.Preprocessor.Directives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NVerilogParser.Preprocessor
{
    public partial class Preprocessor
    {
        private Dictionary<string, string> _definitions;

        private Timescale _timescale;

        public Preprocessor(Func<string, Task<string>> fileProvider = null, Dictionary<string, string> defines = null)
        {
            var macroResolver = MacroResolverFactory.CreateDefault(true, Environment.NewLine);
            macroResolver.Macros.Add(new ExpandedIfDefMacro("`ifdef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedIfNDefMacro("`ifndef", "`else", "`endif"));
            macroResolver.Macros.Add(new ExpandedDefineMacro("`define"));
            macroResolver.Macros.Add(new ExpandedUndefineMacro("`undef"));
            macroResolver.Macros.Add(new ExpandedIncludeMacro("`include"));
            macroResolver.Macros.Add(new RegexActionMacro(@"`timescale (\d+)(\w+)\s*\/\s*(\d+)(\w+)", (Match m) => 
            {
                _timescale = new Timescale
                {
                    TimeUnit = int.Parse(m.Groups[1].Value),
                    TimeUnitScaleFactor = m.Groups[2].Value,
                    TimePrecision = int.Parse(m.Groups[3].Value),
                    TimePrecisionScaleFactor = m.Groups[4].Value
                };
            }, false));

            if (fileProvider != null)
            {
                macroResolver.Macros.OfType<IncludeMacro>().Single().Provider = fileProvider;
            }

            _definitions = defines;

            MacroResolver = macroResolver;
        }

        public IMacroResolver MacroResolver { get; private set; }

        public async Task<PreprocessorResult> DoPreprocessing(string input)
        {
            var txtReader = new TextReader(input, Environment.NewLine);

            var state = new State { DefinitionPrefix = "`" };

            if (_definitions != null)
            {
                foreach (var key in _definitions.Keys)
                {
                    state.Mappings[key] = _definitions[key];
                }
            }
            _timescale = null;

            var directives = new List<Directive>();
            var result = await MacroResolver.Resolve(txtReader, state);

            if (_timescale != null)
            {
                directives.Add(_timescale);
            }

            return new PreprocessorResult()
            {
                Text = string.Join(string.Empty, result.Blocks.Select(b => b.Value)),
                Directives = directives
            };
        }
    }
}
