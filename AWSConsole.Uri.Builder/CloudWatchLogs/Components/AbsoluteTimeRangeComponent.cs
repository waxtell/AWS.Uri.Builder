using System;
using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class AbsoluteTimeRangeComponent : ILogsUriComponent
    {
        private readonly DateTime _start;
        private readonly DateTime _end;

        public AbsoluteTimeRangeComponent(DateTime start, DateTime end)
        {
            _start = start;
            _end = end;
        }

        public string Build()
        {
            return
                $"?start={_start.ToEpochMilliseconds()}&end={_end.ToEpochMilliseconds()}".ToHexString("$", true);
        }
    }
}