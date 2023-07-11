using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Identity;
using Volo.Abp.Localization;
using Volo.Abp.Localization.ExceptionHandling;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;
using Volo.Abp.Validation.Localization;
using Volo.Abp.VirtualFileSystem;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль общих доменных сущностей.
/// </summary>
[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule)
)]
public class MobileMonitoringDomainSharedModule : AbpModule
{
    /// <summary>
    /// Сконфигурировать сервисы модуля.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<AbpVirtualFileSystemOptions>(
            options =>
            {
                options.FileSets.AddEmbedded<MobileMonitoringDomainSharedModule>();
            });

        Configure<AbpLocalizationOptions>(
            options =>
            {
                options.Resources
                    .Add<MobileMonitoringResource>("en")
                    .AddBaseTypes(typeof(AbpValidationResource))
                    .AddVirtualJson("/Localization/MobileMonitoring");

                options.DefaultResourceType = typeof(MobileMonitoringResource);
            });

        Configure<AbpExceptionLocalizationOptions>(
            options =>
            {
                options.MapCodeNamespace("MobileMonitoring", typeof(MobileMonitoringResource));
            });
    }
}
