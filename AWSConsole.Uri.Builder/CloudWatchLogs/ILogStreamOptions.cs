using System;

namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogStreamOptions
    {
        /// <summary>
        /// Restrict the result logs to those that fall between the provided start and end date.
        /// </summary>
        /// <param name="start">Start date/time in UTC</param>
        /// <param name="end">End date/time in UTC</param>
        /// <returns>An ILogStreamOptions which will allow for additional log specificity.</returns>
        ILogStreamOptions WithAbsoluteRange(DateTime start, DateTime end);

        /// <summary>
        /// Restrict the result logs to those that precede the page load by the provided milliseconds value.
        /// </summary>
        /// <param name="lastMilliseconds">The number of milliseconds to consider when restricting logs.</param>
        /// <returns>An ILogStreamOptions which will allow for additional log specificity.</returns>
        ILogStreamOptions WithRelativeRangeMilliseconds(uint lastMilliseconds);

        /// <summary>
        /// Provide a filter to only consider log entries that conform.  Please see https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html for filter and pattern syntax.
        /// </summary>
        /// <param name="filter"></param>
        /// <returns>An ILogStreamOptions which will allow for additional log specificity.</returns>
        ILogStreamOptions WithFilter(string filter);

        /// <summary>
        /// Build the URI from the provided parameters.
        /// </summary>
        /// <returns>The CloudWatch Logs URI</returns>
        System.Uri Build();
    }
}