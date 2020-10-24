using System;
using System.Linq;
using System.Text;

namespace AWS.Uri.Builder.CloudWatchLogsInsights
{
    public class CloudWatchLogsInsightsUriBuilder
    {
        private readonly string _region;
        private DateTime? _start;
        private DateTime? _end;
        private TimeZone? _timeZone;
        private string _query;
        private string[] _logGroups;
        private TimeReferenceType _timeType;
        private bool _liveTail;

        private CloudWatchLogsInsightsUriBuilder(string region)
        {
            _region = region;
        }

        public static CloudWatchLogsInsightsUriBuilder FromRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new ArgumentException($"{nameof(region)} can not be null or empty!");
            }

            return 
                new CloudWatchLogsInsightsUriBuilder(region);
        }

        public CloudWatchLogsInsightsUriBuilder WithLiveTail(bool liveTail)
        {
            _liveTail = liveTail;

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithLogGroups(params string[] logGroups)
        {
            _logGroups = logGroups
                            ?.Where(logGroup => logGroup != null)
                            .ToArray();

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithAbsoluteRange(DateTime start, DateTime end, TimeZone timeZone)
        {
            _start = start;
            _end = end;
            _timeZone = timeZone;
            _timeType = TimeReferenceType.Absolute;

            return this;
        }

        public CloudWatchLogsInsightsUriBuilder WithQuery(string query)
        {
            _query = query;

            return this;
        }

        public System.Uri Build()
        {
            var builder =
                new StringBuilder($"https://{_region}.console.aws.amazon.com/cloudwatch/home?region={_region}#logsV2:logs-insights");

            builder.Append(ToHexString("?queryDetail=", "$", true));

            builder.Append(Escape("=("));

            if (_end.HasValue && _start.HasValue && _timeZone.HasValue)
            {
                builder
                    .Append
                    (
                        Escape($"end='{ToHexString(_end.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ"))}=start='{ToHexString(_start.Value.ToString("yyyy-MM-dd'T'HH:mm:ss.fffZ"))}=timeType='{Enum.GetName(typeof(TimeReferenceType), _timeType)?.ToUpper()}=tz='{Enum.GetName(typeof(TimeZone), _timeZone.Value)}")
                    );
            }

            if (!string.IsNullOrEmpty(_query))
            {
                builder.Append(Escape("=editorString='"));
                builder.Append(ToHexString($"{_query}\n", "*", false, false));
            }

            builder.Append(Escape($"=isLiveTail={_liveTail.ToString().ToLower()}"));

            if (_logGroups != null && _logGroups.Any())
            {
                builder
                    .Append
                    (
                        Escape($"=source=(='{string.Join("='", _logGroups.Select(logGroup => ToHexString(logGroup)))})")
                    );
            }

            builder.Append(Escape(")"));

            return 
                new System.Uri(builder.ToString());

            static string Escape(string src)
            {
                return
                    ToHexString
                    (
                        src
                            .Replace("=", "%~")
                            .Replace("'", "%'")
                            .Replace("(", "%(")
                            .Replace(")", "%)")
                        , "$",
                        true
                    );
            }

            static string ToHexString(string source, string prefix = "*", bool upperCase = false, bool escapeConsecutive = true)
            {
                static bool IsSpecial(char c)
                {
                    return
                        !(
                            char.IsLetterOrDigit(c) ||
                            (c == '_') ||
                            (c == '-') ||
                            (c == '*') ||
                            (c == '.')
                        );
                }

                var sb = new StringBuilder();
                var toHexFormatString = upperCase ? "X2" : "x2";

                var isConsecutive = false;

                foreach (var c in source)
                {
                    if (IsSpecial(c))
                    {
                        if (isConsecutive && escapeConsecutive)
                        {
                            isConsecutive = false;
                        }
                        else
                        {
                            sb.Append(prefix);
                            isConsecutive = true;
                        }

                        sb.Append(((int)c).ToString(toHexFormatString));
                    }
                    else
                    {
                        isConsecutive = false;
                        sb.Append(c);
                    }
                }

                return
                    sb.ToString();
            }
        }
    }
}