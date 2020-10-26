using AWSConsole.Uri.Builder.CloudWatchLogsInsights;
using AWSConsole.Uri.Builder.Extensions;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Theory]
        public void WithLogGroups_NoValidLogGroupsSourceIsExcluded()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLogGroups(null, string.Empty, "   ")
                        .Build();

            Assert
                .False((bool) uri.Fragment.Contains("source=".Escape()));
        }

        [Theory]
        public void WithLogGroups_SingleValidLogGroup()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLogGroups("test")
                        .Build();

            Assert
                .True((bool) uri.Fragment.Contains("source=(='test)".Escape()));
        }

        [Theory]
        public void WithLogGroups_MultipleValidLogGroups()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                .FromRegion("us-east-2")
                .WithLogGroups("test1", "test2")
                .Build();

            Assert
                .True((bool) uri.Fragment.Contains("source=(='test1='test2)".Escape()));
        }
    }
}