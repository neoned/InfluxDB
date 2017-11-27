﻿// <copyright file="MetricsInfluxDBLineProtocolOptions.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.Formatters.InfluxDB.Internal;

namespace App.Metrics.Formatters.InfluxDB
{
    /// <summary>
    ///     Provides programmatic configuration for InfluxDB's LineProtocole format in the App Metrics framework.
    /// </summary>
    public class MetricsInfluxDbLineProtocolOptions
    {
        public MetricsInfluxDbLineProtocolOptions()
        {
            MetricNameMapping = new GeneratedMetricNameMapping();
            MetricNameFormatter = InfluxDbFormatterConstants.LineProtocol.MetricNameFormatter;
        }

        public Func<string, string, string> MetricNameFormatter { get; set; }

        public GeneratedMetricNameMapping MetricNameMapping { get; set; }
    }
}
