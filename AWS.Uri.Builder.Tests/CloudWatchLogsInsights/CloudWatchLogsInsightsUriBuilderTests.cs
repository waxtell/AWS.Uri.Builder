using System;
using AWS.Uri.Builder.CloudWatchLogsInsights;
using NUnit.Framework;

namespace AWS.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public class Tests
    {
        [Test]
        public void FromRegion_ValidRegionProducesCorrectHost()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                        .FromRegion("us-east-2")
                        .Build();

            Assert
                .AreEqual(uri.Host, "us-east-2.console.aws.amazon.com");
        }

        [Test]
        public void FromRegion_NullRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsInsightsUriBuilder.FromRegion(null)
                );
        }

        [Test]
        public void FromRegion_EmptyRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsInsightsUriBuilder.FromRegion(string.Empty)
                );
        }

        [Test]
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