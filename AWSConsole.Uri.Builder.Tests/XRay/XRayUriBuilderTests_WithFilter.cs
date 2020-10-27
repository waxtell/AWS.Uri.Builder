using AWSConsole.Uri.Builder.XRay;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.XRay
{
    public partial class XRayUriBuilderTests
    {
        [Theory]
        public void WithFilter_NullFilterNotAddedToUri()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithFilter(null)
                        .Build();

            Assert
                .IsFalse(uri.Fragment.Contains("filter="));
        }

        [Theory]
        public void WithFilter_EmptyFilterNotAddedToUri()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithFilter(string.Empty)
                        .Build();

            Assert
                .IsFalse(uri.Fragment.Contains("filter="));
        }

        [Theory]
        public void WithFilter_WhitespaceFilterNotAddedToUri()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithFilter("     ")
                        .Build();

            Assert
                .IsFalse(uri.Fragment.Contains("filter="));
        }

        [Theory]
        public void WithFilter_ValidFilterAddedToUri()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithFilter("test")
                        .Build();

            Assert
                .IsTrue(uri.Fragment.Contains("filter=test"));
        }
    }
}