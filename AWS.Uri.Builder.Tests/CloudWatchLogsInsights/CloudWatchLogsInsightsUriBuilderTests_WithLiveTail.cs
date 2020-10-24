using AWS.Uri.Builder.CloudWatchLogsInsights;
using AWS.Uri.Builder.Extensions;
using NUnit.Framework;

namespace AWS.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Test]
        public void WithLiveTail_TrueValueReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLiveTail(true)
                        .Build();

            Assert
                .True(uri.Fragment.Contains("isLiveTail=true".Escape()));
        }

        [Test]
        public void WithLiveTail_FalseValueReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLiveTail(false)
                        .Build();

            Assert
                .True(uri.Fragment.Contains("isLiveTail=false".Escape()));
        }

        [Test]
        public void WithLiveTail_DefaultValueOfFalseReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .Build();

            Assert
                .True(uri.Fragment.Contains("isLiveTail=false".Escape()));
        }
    }
}