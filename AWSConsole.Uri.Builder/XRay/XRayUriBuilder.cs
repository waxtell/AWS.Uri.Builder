using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AWSConsole.Uri.Builder.XRay.Metadata;

namespace AWSConsole.Uri.Builder.XRay
{
    public class XRayUriBuilder
    {
        private readonly string _region;
        private readonly IDictionary<string,string> _queryString = new Dictionary<string, string>();

        private XRayUriBuilder(string region)
        {
            _region = region;
        }

        public static XRayUriBuilder FromRegion(string region)
        {
            if (string.IsNullOrWhiteSpace(region))
            {
                throw new ArgumentException($"{nameof(region)} can not be null or empty!");
            }

            return 
                new XRayUriBuilder(region);
        }

        public XRayUriBuilder WithAbsoluteRange(DateTime start, DateTime end)
        {
            _queryString[Constants.timeRange] = $"{start.ToString(Constants.DateTimeFormatString)}~{end.ToString(Constants.DateTimeFormatString)}";

            return this;
        }

        public XRayUriBuilder WithRelativeRangeMinutes(uint lastMinutes)
        {
            if (lastMinutes > Constants.MaxMinutes)
            {
                throw new ArgumentException($"{nameof(lastMinutes)} can not be greater than {Constants.MaxMinutes}!");
            }

            _queryString[Constants.timeRange] = $"{ToRelativeTimeString()}";

            return this;

            string ToRelativeTimeString()
            {
                var hours = Math.DivRem(lastMinutes, 60, out var minutes);

                var sb = new StringBuilder("PT");

                if (hours > 0)
                {
                    sb.Append($"{hours}H");
                }

                if (minutes > 0)
                {
                    sb.Append($"{minutes}M");
                }

                return
                    sb.ToString();
            }
        }

        public XRayUriBuilder WithFilter(string filter)
        {
            if (!string.IsNullOrWhiteSpace(filter))
            {
                _queryString[Constants.filter] = System.Uri.EscapeUriString(filter);
            }

            return this;
        }

        public System.Uri Build()
        {
            var builder = new StringBuilder($"https://{_region}.console.aws.amazon.com/xray/home?region={_region}#/traces");

            if (_queryString.Any())
            {
                builder
                    .Append("?")
                    .Append(string.Join("&", _queryString.Select(kvp => $"{kvp.Key}={kvp.Value}")));
            }

            return 
                new System.Uri(builder.ToString());
       }
    }
}