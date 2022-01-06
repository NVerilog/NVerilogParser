using CFGToolkit.ParserCombinator;
using CFGToolkit.ParserCombinator.Input;
using NPreprocessor.Macros;
using NVerilogParser.Lexer;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace NVerilogParser.Tests
{
    public abstract class BaseTests
    {
        protected abstract string IncludePath { get; }

        protected abstract string BasePath { get; }

        protected string GetTextFromFile(string basePath, string fileName)
        {
            return File.ReadAllText(@$"{basePath}\{fileName}");
        }

        protected virtual string Prefix { get; set; } = string.Empty;

        protected void Check(string testPath)
        {
            var parser = new VerilogParser((fileName) => GetTextFromFile(IncludePath, fileName));
            string txt = Prefix + GetTextFromFile(BasePath, testPath);

            var timeout = 1000 * 60 * 10;

            IUnionResult<CharToken> results = null;

            var task = new Task(() => { results = parser.TryParse(txt); });
            task.Start();
            var result = Task.WaitAll(new[] { task }, timeout);
            Assert.True(result, txt);

            var state = results.GlobalState;
            if (!results.WasSuccessful)
            {
                var nonConsumed = results.Input.Source.Skip(state.LastConsumedPosition + 1);
                string ctxt = string.Join("", nonConsumed.Select(s => s.Value));
                Assert.True(false, ctxt + "\r\n==\r\n" + txt);
            }

            Assert.True(results.WasSuccessful, txt);
            Assert.True(results.Values.Count == 1, txt);
            Assert.False(results.Values[0].EmptyMatch);
        }
    }
}
