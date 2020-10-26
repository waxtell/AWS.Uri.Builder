using System;
using AWSConsole.Uri.Builder.CloudWatchLogsInsights;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Theory]
        public void FromRegion_ValidRegionProducesCorrectHost()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .Build();

            Assert
                .AreEqual(uri.Host, "us-east-2.console.aws.amazon.com");

            Assert
                .IsTrue(uri.Query.Contains("region=us-east-2"));
        }

        [Theory]
        public void FromRegion_NullRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsInsightsUriBuilder.FromRegion(null)
                );
        }

        [Theory]
        public void FromRegion_EmptyRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsInsightsUriBuilder.FromRegion(string.Empty)
                );
        }

        [Theory]
        public void FromRegion_WhiteSpaceRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsInsightsUriBuilder.FromRegion("     ")
                );
        }
    }
}