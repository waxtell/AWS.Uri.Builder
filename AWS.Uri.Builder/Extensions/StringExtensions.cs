using System.Text;

namespace AWS.Uri.Builder.Extensions
{
    internal static class StringExtensions
    {
        public static string Escape(this string src)
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

        public static string ToHexString(this string source, string prefix = "*", bool upperCase = false, bool escapeConsecutive = true)
        {
            bool IsSpecial(char c)
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
