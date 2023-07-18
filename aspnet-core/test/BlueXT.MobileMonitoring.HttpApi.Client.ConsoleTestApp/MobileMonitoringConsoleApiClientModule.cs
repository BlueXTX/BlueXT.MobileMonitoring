using System;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using Volo.Abp.Autofac;
using Volo.Abp.Http.Client;
using Volo.Abp.Http.Client.IdentityModel;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.HttpApi.Client.ConsoleTestApp;

/// <summary>
/// Модуль консольного тестирования Api.
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MobileMonitoringHttpApiClientModule),
    typeof(AbpHttpClientIdentityModelModule)
)]
public class MobileMonitoringConsoleApiClientModule : AbpModule
{
    /// <summary>
    /// Предварительная конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void PreConfigureServices(ServiceConfigurationContext context) =>
        PreConfigure<AbpHttpClientBuilderOptions>(
            options =>
            {
                options.ProxyClientBuildActions.Add(
                    (_, clientBuilder) =>
                    {
                        clientBuilder.AddTransientHttpErrorPolicy(
                            policyBuilder => policyBuilder.WaitAndRetryAsync(retryCount: 3, i => TimeSpan.FromSeconds(Math.Pow(x: 2, i)))
                        );
                    });
            });
}
