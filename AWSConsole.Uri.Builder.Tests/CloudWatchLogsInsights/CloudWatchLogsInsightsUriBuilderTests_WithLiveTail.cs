using AWSConsole.Uri.Builder.CloudWatchLogsInsights;
using AWSConsole.Uri.Builder.Extensions;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Theory]
        public void WithLiveTail_TrueValueReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLiveTail(true)
                        .Build();

            Assert
                .True(uri.Fragment.Contains("isLiveTail~true".Escape()));
        }

        [Theory]
        public void WithLiveTail_FalseValueReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .WithLiveTail(false)
                        .Build();

            Assert
                .True((bool) uri.Fragment.Contains("isLiveTail~false".Escape()));
        }

        [Theory]
        public void WithLiveTail_DefaultValueOfFalseReflectedInQueryString()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .Build();

            Assert
                .True(uri.Fragment.Contains("isLiveTail~false".Escape()));
        }
    }
}