# AWS.Uri.Builder
Fluent builder for AWS service URIs

Usage:

``` csharp
var uri = CloudWatchLogsInsightsUriBuilder
            .FromRegion("us-east-2")
            .WithLogGroups("your_log_group")
            .WithAbsoluteRange(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), TimeZone.UTC)
            .WithQuery($"fields @timestamp, @message\n| filter @requestId = \"your_request_id\"\n| sort @timestamp desc")
            .Build();
```
Generates the following query string:
```
https://us-east-2.console.aws.amazon.com/cloudwatch/home?region=us-east-2#logsV2:logs-insights$3FqueryDetail$3D$257E$2528end$257E$25272020-10-24T23*3a21*3a07.013Z$257Estart$257E$25272020-10-24T23*3a11*3a06.998Z$257EtimeType$257E$2527ABSOLUTE$257Etz$257E$2527UTC$257EeditorString$257E$2527fields*20*40timestamp*2c*20*40message*0a*7c*20filter*20*40requestId*20*3d*20*22your_request_id*22*0a*7c*20sort*20*40timestamp*20desc*0a$257EisLiveTail$257Efalse$257Esource$257E$2528$257E$2527your_log_group$2529$2529
```

