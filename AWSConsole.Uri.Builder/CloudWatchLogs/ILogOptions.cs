namespace AWSConsole.Uri.Builder.CloudWatchLogs
{
    public interface ILogOptions
    {
        ILogGroupOptions WithLogGroup(string logGroup);
        IBuild WithLogGroupNameFilter(string logGroupNameFilter);
        System.Uri Build();
    }
}