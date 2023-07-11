using Volo.Abp.Account;
using Volo.Abp.AutoMapper;
using Volo.Abp.FluentValidation;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace BlueXT.MobileMonitoring;

[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpFluentValidationModule)
)]
public class MobileMonitoringApplicationModule : AbpModule
{
    public override void ConfigureServices(ServiceConfigurationContext context) =>
        Configure<AbpAutoMapperOptions>(
            options =>
            {
                options.AddMaps<MobileMonitoringApplicationModule>();
            });
}
