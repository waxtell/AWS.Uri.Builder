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
            const TimeZoneType tzt = TimeZoneType.Local;

            Assert
                .AreEqual(nameof(TimeZoneType.Local), tzt.TryGetName());
        }

        [Theory]
        public void TryGetName_InValidValueResolvesToNull()
        {
            const TimeZoneType tzt = (TimeZoneType) int.MaxValue;

            Assert
                .AreEqual(null, tzt.TryGetName());
        }
    }
}
