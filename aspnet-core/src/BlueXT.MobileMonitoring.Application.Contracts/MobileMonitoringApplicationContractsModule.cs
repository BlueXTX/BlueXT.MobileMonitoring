﻿using Volo.Abp.Account;
using Volo.Abp.Identity;
using Volo.Abp.Modularity;
using Volo.Abp.ObjectExtending;
using Volo.Abp.PermissionManagement;
using Volo.Abp.SettingManagement;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль контрактов приложения.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringDomainSharedModule),
    typeof(AbpAccountApplicationContractsModule),
    typeof(AbpIdentityApplicationContractsModule),
    typeof(AbpPermissionManagementApplicationContractsModule),
    typeof(AbpSettingManagementApplicationContractsModule),
    typeof(AbpObjectExtendingModule)
)]
public class MobileMonitoringApplicationContractsModule : AbpModule
{
}
