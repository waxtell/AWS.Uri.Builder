using AWSConsole.Uri.Builder.CloudWatchLogsInsights;
using AWSConsole.Uri.Builder.Extensions;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.Extensions
{
    public class EnumExtensionsTests
    {
        [Theory]
        public void TryGetName_ValidValueResolvesToName()
        {
            var trt = TimeReferenceType.Absolute;

            Assert
                .AreEqual(nameof(TimeReferenceType.Absolute), trt.TryGetName());
        }

        [Theory]
        public void TryGetName_InValidValueResolvesToNull()
        {
            var trt = (TimeReferenceType) int.MaxValue;

            Assert
                .AreEqual(null, trt.TryGetName());
        }
    }
}
