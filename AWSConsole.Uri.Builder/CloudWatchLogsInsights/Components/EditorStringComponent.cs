using AWSConsole.Uri.Builder.Extensions;

namespace AWSConsole.Uri.Builder.CloudWatchLogsInsights.Components
{
    internal class EditorStringComponent : IInsightUriComponent
    {
        private readonly string _query;

        public EditorStringComponent(string query)
        {
            _query = query;
        }

        public string Build()
        {
            return
                string
                    .Join
                    (
                        "='".Escape(),
                        "editorString",
                        $"{_query}\n".ToHexString("*", false, false)
                    );
        }
    }
}