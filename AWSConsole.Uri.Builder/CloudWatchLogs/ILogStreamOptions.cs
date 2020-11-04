using System;

namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogStreamOptions
    {
        ILogStreamOptions WithAbsoluteRange(DateTime start, DateTime end);
        ILogStreamOptions WithRelativeRangeMilliseconds(uint lastMilliseconds);
        ILogStreamOptions WithFilter(string filter);
        System.Uri Build();
    }
}