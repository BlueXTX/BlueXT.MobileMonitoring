﻿using System;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.HttpApi.Client.ConsoleTestApp;

[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MobileMonitoringHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class MobileMonitoringConsoleApiClientModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) =>
        PreConfigure<AbpHttpClientBuilderOptions>(
            options =>
            {
                options.ProxyClientBuildActions.Add(
                    (remoteServiceName, clientBuilder) =>
                    {
                        clientBuilder.AddTransientHttpErrorPolicy(
                            policyBuilder => policyBuilder.WaitAndRetryAsync(retryCount: 3, i => TimeSpan.FromSeconds(Math.Pow(x: 2, i)))
                        );
                    });
            });
}
