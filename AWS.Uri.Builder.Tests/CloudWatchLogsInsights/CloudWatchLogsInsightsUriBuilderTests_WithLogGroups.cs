using AWS.Uri.Builder.CloudWatchLogsInsights;
using AWS.Uri.Builder.Extensions;
using NUnit.Framework;

namespace AWS.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Test]
        public void WithLogGroups_NoValidLogGroupsSourceIsExcluded()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLogGroups(null, string.Empty, "   ")
                        .Build();

            Assert
                .False(uri.Fragment.Contains("source=".Escape()));
        }

        [Test]
        public void WithLogGroups_SingleValidLogGroup()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLogGroups("test")
                        .Build();

            Assert
                .True(uri.Fragment.Contains("source=(='test)".Escape()));
        }

        [Test]
        public void WithLogGroups_MultipleValidLogGroups()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                .FromRegion("us-east-2")
                .WithLogGroups("test1", "test2")
                .Build();

            Assert
                .True(uri.Fragment.Contains("source=(='test1='test2)".Escape()));
        }
    }
}