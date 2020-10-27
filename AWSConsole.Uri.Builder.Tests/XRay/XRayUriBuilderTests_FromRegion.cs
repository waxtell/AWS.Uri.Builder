using System;
using AWSConsole.Uri.Builder.XRay;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.XRay
{
    public partial class XRayUriBuilderTests
    {
        [Theory]
        public void FromRegion_ValidRegionProducesCorrectHost()
        {
            var uri = XRayUriBuilder
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
                    () => XRayUriBuilder.FromRegion(null)
                );
        }

        [Theory]
        public void FromRegion_EmptyRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => XRayUriBuilder.FromRegion(string.Empty)
                );
        }

        [Theory]
        public void FromRegion_WhiteSpaceRegionThrowsArgumentException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => XRayUriBuilder.FromRegion("     ")
                );
        }
    }
}