namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogGroupOptions
    {
        /// <summary>
        /// Restrict filters, etc. to the provided log stream.
        /// </summary>
        /// <param name="logStream">Filters, ranges, etc. will apply exclusively to this log stream.</param>
        /// <returns>An ILogStreamOptions which will allow for additional log stream specificity.</returns>
        ILogStreamOptions WithLogStream(string logStream);

        /// <summary>
        /// Search for log streams that match the provided name filter.  Please see https://docs.aws.amazon.com/AmazonCloudWatch/latest/logs/FilterAndPatternSyntax.html for filter and pattern syntax.
        /// </summary>
        /// <param name="logStreamNameFilter"></param>
        /// <returns>The only thing left to do now is Build()</returns>
        IBuild WithLogStreamNameFilter(string logStreamNameFilter);

        /// <summary>
        /// Build the URI from the provided parameters.
        /// </summary>
        /// <returns>The CloudWatch Logs URI</returns>
        System.Uri Build();
    }
}