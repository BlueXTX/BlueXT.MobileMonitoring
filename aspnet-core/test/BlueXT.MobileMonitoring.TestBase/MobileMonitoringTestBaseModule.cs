using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Authorization;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Data;
using Volo.Abp.Modularity;
using Volo.Abp.Threading;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль упрощающий работу с тестированием.
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpTestBaseModule),
    typeof(AbpAuthorizationModule),
    typeof(MobileMonitoringDomainModule)
)]
public class MobileMonitoringTestBaseModule : AbpModule
{
    /// <summary>
    /// Сконфигурировать сервисы.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        ConfigureBackgroundJobOptions();
        ConfigureAuthorization(context);
    }

    /// <summary>
    /// Инициализация приложения.
    /// </summary>
    /// <param name="context">Контекст инициализации.</param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context) => SeedTestData(context);

    private static void ConfigureAuthorization(ServiceConfigurationContext context) => context.Services.AddAlwaysAllowAuthorization();

    private static void SeedTestData(ApplicationInitializationContext context) =>
        AsyncHelper.RunSync(
            async () =>
            {
                using var scope = context.ServiceProvider.CreateScope();
                await scope.ServiceProvider
                    .GetRequiredService<IDataSeeder>()
                    .SeedAsync();
            });

    private void ConfigureBackgroundJobOptions() =>
        Configure<AbpBackgroundJobOptions>(
            options => { options.IsJobExecutionEnabled = false; });
}
