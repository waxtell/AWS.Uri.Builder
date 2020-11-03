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
                        .WithLogGroup("/onprem/api/RegisterApi/prod")
                        //.WithRelativeRangeMilliseconds(600000)
                        //.WithAbsoluteRange(DateTime.UtcNow.AddHours(-1), DateTime.UtcNow.AddHours(5))
                        .WithFilter("{ $.Level = \"Error\" }")
                        .WithLogStreamNameFilter("2020-11-02")
                        .WithLogStream("2020-11-02-06-52-03_TRProdAPI01_12ad2df0-fbd1-40a9-bc93-a483f63e4f09")
                        .WithLogGroupNameFilter("aws/")
                        .Build();

            var s = uri.ToString();

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