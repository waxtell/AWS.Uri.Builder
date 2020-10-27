using System;
using AWSConsole.Uri.Builder.XRay;
using AWSConsole.Uri.Builder.XRay.Metadata;
using NUnit.Framework;

namespace AWSConsole.Uri.Builder.Tests.XRay
{
    public partial class XRayUriBuilderTests
    {
        [Theory]
        public void WithRelativeRangeMinutes_OneHourZeroMinutes()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithRelativeRangeMinutes(60)
                        .Build();

            Assert
                .IsTrue(uri.Fragment.Contains($"{Constants.timeRange}=PT1H"));
        }

        [Theory]
        public void WithRelativeRangeMinutes_ZeroHoursTenMinutes()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithRelativeRangeMinutes(10)
                        .Build();

            Assert
                .IsTrue(uri.Fragment.Contains($"{Constants.timeRange}=PT10M"));
        }

        [Theory]
        public void WithRelativeRangeMinutes_OneHourTenMinutes()
        {
            var uri = XRayUriBuilder
                        .FromRegion("us-east-2")
                        .WithRelativeRangeMinutes(70)
                        .Build();

            Assert
                .IsTrue(uri.Fragment.Contains($"{Constants.timeRange}=PT1H10M"));
        }

        [Theory]
        public void WithRelativeRangeMinutes_ExceedsMaxMinutesThrowException()
        {
            Assert
                .Throws<ArgumentException>
                (
                    () => XRayUriBuilder.FromRegion("us-east-2").WithRelativeRangeMinutes(Constants.MaxMinutes+1)
                );
        }
    }
}