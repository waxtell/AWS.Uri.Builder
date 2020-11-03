using System;

namespace AWSConsole.Uri.Builder.Extensions
{
    public static class DateTimeExtensions
    {
        public static long ToEpochSeconds(this DateTime datetime) =>
            (long)
                datetime
                    .Subtract(new DateTime(1970, 1, 1))
                        .TotalMilliseconds;
    }
}
