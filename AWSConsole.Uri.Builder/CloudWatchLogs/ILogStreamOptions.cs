using System;

namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogStreamOptions
    {
        ILogStreamOptions WithAbsoluteRange(DateTime start, DateTime end);
        ILogStreamOptions WithRelativeRangeMilliseconds(uint lastMilliseconds);
        ILogStreamOptions WithFilter(string filter);

        /// <summary>
        /// Build the URI from the provided parameters.
        /// </summary>
        /// <returns>The CloudWatch Logs URI</returns>
        System.Uri Build();
    }
}