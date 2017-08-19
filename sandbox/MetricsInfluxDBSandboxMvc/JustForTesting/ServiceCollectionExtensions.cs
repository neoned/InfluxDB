﻿// <copyright file="ServiceCollectionExtensions.cs" company="Allan Hardy">
// Copyright (c) Allan Hardy. All rights reserved.
// </copyright>

using System;
using App.Metrics.AspNetCore.TrackingMiddleware;
using MetricsInfluxDBSandboxMvc.JustForTesting;
using Microsoft.Extensions.Options;

// ReSharper disable CheckNamespace
namespace Microsoft.Extensions.DependencyInjection
    // ReSharper restore CheckNamespace
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddTestStuff(this IServiceCollection services)
        {
            services.AddTransient<Func<double, RequestDurationForApdexTesting>>(
                provider => { return apdexTSeconds => new RequestDurationForApdexTesting(apdexTSeconds); });

            services.AddTransient<RandomStatusCodeForTesting>();

            services.AddTransient(
                serviceProvider =>
                {
                    var optionsAccessor = serviceProvider.GetRequiredService<IOptions<MetricsTrackingMiddlewareOptions>>();
                    return new RequestDurationForApdexTesting(optionsAccessor.Value.ApdexTSeconds);
                });

            return services;
        }
    }
}