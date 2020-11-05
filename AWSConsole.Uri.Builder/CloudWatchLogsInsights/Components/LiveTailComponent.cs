using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components
{
    internal class LiveTailComponent : IInsightUriComponent
    {
        private readonly bool _liveTail;

        public LiveTailComponent(bool liveTail)
        {
            _liveTail = liveTail;
        }

        public string Build()
        {
            return
                string
                    .Join
                    (
                        "~",
                        "isLiveTail",
                        $"{_liveTail.ToString().ToLower()}"
                    )
                    .Escape();
        }
    }
}