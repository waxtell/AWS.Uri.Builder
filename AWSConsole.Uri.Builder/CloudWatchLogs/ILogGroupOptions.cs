namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogGroupOptions
    {
        ILogStreamOptions WithLogStream(string logStream);
        IBuild WithLogStreamNameFilter(string logStreamNameFilter);
        System.Uri Build();
    }
}