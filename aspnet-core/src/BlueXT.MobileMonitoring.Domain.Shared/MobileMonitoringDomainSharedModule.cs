﻿using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.AuditLogging;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.FeatureManagement;
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

[DependsOn(
    typeof(AbpAuditLoggingDomainSharedModule),
    typeof(AbpBackgroundJobsDomainSharedModule),
    typeof(AbpFeatureManagementDomainSharedModule),
    typeof(AbpIdentityDomainSharedModule),
    typeof(AbpOpenIddictDomainSharedModule),
    typeof(AbpPermissionManagementDomainSharedModule),
    typeof(AbpSettingManagementDomainSharedModule)
)]
public class MobileMonitoringDomainSharedModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        MobileMonitoringGlobalFeatureConfigurator.Configure();
        MobileMonitoringModuleExtensionConfigurator.Configure();
    }

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
