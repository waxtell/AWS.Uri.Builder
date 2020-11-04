namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface IBuild
    {
        /// <summary>
        /// Build the URI from the provided parameters.
        /// </summary>
        /// <returns>The CloudWatch Logs URI</returns>
        System.Uri Build();
    }
}