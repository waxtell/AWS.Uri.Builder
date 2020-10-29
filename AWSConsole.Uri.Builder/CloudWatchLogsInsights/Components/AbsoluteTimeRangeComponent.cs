using System;
using AWSConsole.Uri.Builder.CloudWatchLogsInsights.Metadata;
using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components
{
    internal class AbsoluteTimeRangeComponent : IInsightUriComponent
    {
        private readonly DateTime _start;
        private readonly DateTime _end;
        private readonly TimeZoneType _timeZoneType;

        public AbsoluteTimeRangeComponent(DateTime start, DateTime end, TimeZoneType timeZoneTypeType)
        {
            _start = start;
            _end = end;
            _timeZoneType = timeZoneTypeType;
        }

        public string Build()
        {
            return
                string
                    .Join
                    (
                        "=",
                        $"end='{_end.ToString(Constants.DateTimeFormatString).ToHexString()}",
                        $"start='{_start.ToString(Constants.DateTimeFormatString).ToHexString()}",
                        "timeType='ABSOLUTE",
                        $"tz='{_timeZoneType.TryGetName()}"
                    )
                    .Escape();
        }
    }
}