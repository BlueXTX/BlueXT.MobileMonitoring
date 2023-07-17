using BlueXT.MobileMonitoring.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль http API приложения.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
)]
public class MobileMonitoringHttpApiModule : AbpModule
{
    /// <summary>
    /// Конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context) => ConfigureLocalization();

    private void ConfigureLocalization() =>
        Configure<AbpLocalizationOptions>(
            options =>
            {
                options.Resources
                    .Get<MobileMonitoringResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
}
