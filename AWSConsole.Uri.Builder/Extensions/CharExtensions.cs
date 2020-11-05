namespace AWSConsole.Uri.Builder.Extensions
{
    internal static class CharExtensions
    {
        public static bool IsSpecial(this char c)
        {
            return
                !(
                    char.IsLetterOrDigit(c) ||
                    (c == '_') ||
                    (c == '-') ||
                    (c == '*') ||
                    (c == '.') ||
                    (c == ' ')
                );
        }
    }
}
