using System;
using AWSConsole.Uri.Builder.CloudWatchLogs;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.CloudWatchLogs
{
    public partial class CloudWatchLogsUriBuilderTests
    {
        [Theory]
        public void FromRegion_ValidRegionProducesCorrectHost()
        {
            var uri = CloudWatchLogsUriBuilder
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
                    () => CloudWatchLogsUriBuilder.FromRegion(null)
                );
        }

        [Theory]
        public void FromRegion_EmptyRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsUriBuilder.FromRegion(string.Empty)
                );
        }

        [Theory]
        public void FromRegion_WhiteSpaceRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => CloudWatchLogsUriBuilder.FromRegion("     ")
                );
        }
    }
}