using CFGToolkit.ParserCombinator.Input;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Xunit;

namespace NVerilogParser.Tests
{
    public abstract class BaseTests
    {
        protected abstract string IncludePath { get; }

        protected abstract string BasePath { get; }

        protected Dictionary<string, string> Definitions { get; set; }

        protected string GetTextFromFile(string basePath, string fileName)
        {
            return File.ReadAllText(@$"{basePath}\{fileName}");
        }

        protected virtual string Prefix { get; set; } = string.Empty;

        protected void Check(string testPath)
        {
            var parser = new VerilogParser((fileName) => Task.FromResult(GetTextFromFile(IncludePath, fileName)), Definitions);
            string txt = Prefix + GetTextFromFile(BasePath, testPath);

            var timeout = 1000 * 60 * 10;

            VerilogParserResult result = null;

            var task = new Task(async () => { result = await parser.TryParse(txt); });
            task.Start();
            var taskResult = Task.WaitAll(new[] { task }, timeout);
            Assert.True(taskResult, txt);

            var state = result.GlobalState;
            if (!result.IsSuccessful)
            {
                var reminder = result.Input.GetReminder(state.LastConsumedPosition + 1);

                var consumed = state.LastConsumedCallStack?.Value;
                var failed = state.GetUniqueFailedCallStacks();

                Assert.True(false, reminder);
            }

            Assert.True(result.IsSuccessful, txt);
            Assert.False(result.IsAmbiguous);
            Assert.False(result.EmptyMatch);
        }
    }
}
