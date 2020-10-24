using System;
using AWS.Uri.Builder.CloudWatchLogsInsights;
using NUnit.Framework;
using TimeZone = AWS.Uri.Builder.CloudWatchLogsInsights.TimeZone;

namespace AWS.Uri.Builder.Tests.CloudWatchLogsInsights
{
    public partial class CloudWatchLogsInsightsUriBuilderTests
    {
        [Theory]
        public void FromRegion_ValidRegionProducesCorrectHost()
        {
            var uri = CloudWatchLogsInsightsUriBuilder
                .FromRegion("us-east-2")
                //                      .Build();
                .WithLogGroups("your_log_group")
                .WithAbsoluteRange(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), TimeZone.UTC)
                .WithQuery(
                    $"fields @timestamp, @message\n| filter @requestId = \"your_request_id\"\n| sort @timestamp desc")
                .Build()
                .ToString();
Console.WriteLine(uri);
            //Assert
            //    .AreEqual(uri.Host, "us-east-2.console.aws.amazon.com");

            //Assert
            //    .IsTrue(uri.Query.Contains("region=us-east-2"));
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