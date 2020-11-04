using System.Text;

namespace AWSConsole.Uri.Builder.Extensions
{
    internal static class StringExtensions
    {
        public static string Escape(this string src)
        {
            var sb = new StringBuilder();

            foreach (var c in src)
            {
                if (c.IsSpecial())
                {
                    sb.Append('%');
                }

                sb.Append(c);
            }

            return 
                sb
                    .ToString()
                    .ToHexString("$", true);
        }

        public static string ToHexString(this string source, string prefix = "*", bool upperCase = false, bool escapeConsecutive = true)
        {
            var sb = new StringBuilder();
            var toHexFormatString = upperCase ? "X2" : "x2";

            var isConsecutive = false;

            foreach (var c in source)
            {
                if (c.IsSpecial())
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
