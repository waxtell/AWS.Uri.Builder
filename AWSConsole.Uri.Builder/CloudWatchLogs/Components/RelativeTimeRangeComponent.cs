using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogs.Components
{
    internal class RelativeTimeRangeComponent : ILogsUriComponent
    {
        private readonly uint _milliseconds;

        public RelativeTimeRangeComponent(uint milliseconds)
        {
            _milliseconds = milliseconds;
        }

        public string Build()
        {
            return
                $"?start=-{_milliseconds}".ToHexString("$", true);
        }
    }
}