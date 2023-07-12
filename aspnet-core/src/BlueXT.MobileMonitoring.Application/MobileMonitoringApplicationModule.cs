using BlueXT.MobileMonitoring.Application.Mapster;
using Volo.Abp.Account;
using Volo.Abp.FluentValidation;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Определение модуля MobileMonitoringApplication.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(AbpAccountApplicationModule),
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpIdentityApplicationModule),
    typeof(AbpPermissionManagementApplicationModule),
    typeof(AbpSettingManagementApplicationModule),
    typeof(AbpFluentValidationModule),
    typeof(MobileMonitoringApplicationMapsterModule)
)]
public class MobileMonitoringApplicationModule : AbpModule
{
}
