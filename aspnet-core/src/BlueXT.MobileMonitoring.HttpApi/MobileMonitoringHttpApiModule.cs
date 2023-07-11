using BlueXT.MobileMonitoring.Localization;
using Localization.Resources.AbpUi;
using Volo.Abp.Account;
using Volo.Abp.FeatureManagement;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement.HttpApi;
using Volo.Abp.SettingManagement;

namespace BlueXT.MobileMonitoring;

[DependsOn(
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpIdentityHttpApiModule),
    typeof(AbpPermissionManagementHttpApiModule),
    typeof(AbpFeatureManagementHttpApiModule),
    typeof(AbpSettingManagementHttpApiModule)
)]
public class MobileMonitoringHttpApiModule : AbpModule
{
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
