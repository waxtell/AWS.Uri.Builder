using System;

namespace AWSConsole.Uri.Builder.Extensions
{
    internal static class DateTimeExtensions
    {
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1);

        public static long ToEpochMilliseconds(this DateTime datetime) =>
            (long)
                datetime
                    .Subtract(Epoch)
                        .TotalMilliseconds;
    }
}
