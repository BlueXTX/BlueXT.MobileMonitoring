using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.VirtualFileSystem;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль http клиента для приложения.   
/// </summary>
[DependsOn(
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpAccountHttpApiClientModule),
    typeof(AbpIdentityHttpApiClientModule),
    typeof(AbpPermissionManagementHttpApiClientModule),
    typeof(AbpSettingManagementHttpApiClientModule)
)]
public class MobileMonitoringHttpApiClientModule : AbpModule
{
    /// <summary>
    /// Имя удаленного сервиса.
    /// </summary>
    public const string RemoteServiceName = "Default";

    /// <summary>
    /// Конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        context.Services.AddHttpClientProxies(
            typeof(MobileMonitoringApplicationContractsModule).Assembly
        );

        Configure<AbpVirtualFileSystemOptions>(
            options =>
            {
                options.FileSets.AddEmbedded<MobileMonitoringHttpApiClientModule>();
            });
    }
}
