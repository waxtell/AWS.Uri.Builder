# AWSConsole.Uri.Builder
Fluent builder for AWS console service URIs.  Presently only CloudWatch Logs, CloudWatch Logs Insights and XRay uri generation are implemented.

![Build](https://github.com/waxtell/AWS.Uri.Builder/workflows/Build/badge.svg)
![Publish to nuget](https://github.com/waxtell/AWS.Uri.Builder/workflows/Publish%20to%20nuget/badge.svg?branch=main)

## Usage for Insights:

``` csharp
var uri = CloudWatchLogsInsightsUriBuilder
            .FromRegion("us-east-2")
            .WithLogGroups("your_log_group")
            .WithAbsoluteRange(DateTime.UtcNow, DateTime.UtcNow.AddMinutes(10), TimeZoneType.UTC)
            .WithQuery($"fields @timestamp, @message\n| filter @requestId = \"your_request_id\"\n| sort @timestamp desc")
            .Build();
```
Generates the following query string:
```
https://us-east-2.console.aws.amazon.com/cloudwatch/home?region=us-east-2#logsV2:logs-insights$3FqueryDetail$3D$257E$2528end$257E$25272020-10-24T23*3a21*3a07.013Z$257Estart$257E$25272020-10-24T23*3a11*3a06.998Z$257EtimeType$257E$2527ABSOLUTE$257Etz$257E$2527UTC$257EeditorString$257E$2527fields*20*40timestamp*2c*20*40message*0a*7c*20filter*20*40requestId*20*3d*20*22your_request_id*22*0a*7c*20sort*20*40timestamp*20desc*0a$257EisLiveTail$257Efalse$257Esource$257E$2528$257E$2527your_log_group$2529$2529
```
Which, when opened in the AWS CloudWatch Logs Insights Portal looks like this:

![](https://raw.githubusercontent.com/waxtell/AWSConsole.Uri.Builder/develop/assets/insightsportal.png)

## Usage for XRay:

``` csharp
var uri = XRayUriBuilder
			.FromRegion("us-east-2")
			.WithFilter("service(\"your service name goes here\")")			
			.WithRelativeRangeMinutes(70)
			.Build();
```
Generates the following query string:
```
https://us-east-2.console.aws.amazon.com/xray/home?region=us-east-2#/traces?filter=service("your service name goes here")&timeRange=PT1H10M
```
Which, when opened in the AWS XRay Traces Portal looks like this:

![](https://raw.githubusercontent.com/waxtell/AWSConsole.Uri.Builder/develop/assets/xrayportal.png)

## Usage for CloudWatch Logs:

``` csharp
var uri = CloudWatchLogsUriBuilder
            .FromRegion("us-east-2")
            .WithLogGroupNameFilter("aws/lambda")
            .Build();
```
Generates the following query string:
```
https://us-east-2.console.aws.amazon.com/cloudwatch/home?region=us-east-2#logsV2:log-groups$3FlogGroupNameFilter$3Daws$252Flambda
```
Which, when opened in the AWS CloudWatch Logs Portal looks like this:

![](https://raw.githubusercontent.com/waxtell/AWSConsole.Uri.Builder/develop/assets/logsportal.png)
