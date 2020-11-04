using AWSConsole.Uri.Builder.CloudWatchLogs.Components;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.CloudWatchLogs.Components
{
    public class LogGroupComponentTests
    {
        [Theory]
        public void Build_NoSpecialCharacters()
        {
            var result = new LogGroupComponent("test").Build();

            Assert.AreEqual("/log-group/test", result);
        }

        [Theory]
        public void Build_SpecialCharacters()
        {
            var result = new LogGroupComponent("test/test").Build();

            // ReSharper disable once StringLiteralTypo
            Assert.AreEqual("/log-group/test$252Ftest", result);
        }
    }
}