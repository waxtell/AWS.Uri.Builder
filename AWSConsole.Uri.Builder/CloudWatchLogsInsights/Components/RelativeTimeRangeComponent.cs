using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components
{
    internal class RelativeTimeRangeComponent : IInsightUriComponent
    {
        private readonly uint _seconds;

        public RelativeTimeRangeComponent(uint seconds)
        {
            _seconds = seconds;
        }

        public string Build()
        {
            return
                string
                    .Join
                    (
                        "~",
                        "end~0",
                        $"start~-{_seconds}",
                        "timeType~'RELATIVE",
                        "unit~'seconds"
                    )
                    .Escape();
        }
    }
}