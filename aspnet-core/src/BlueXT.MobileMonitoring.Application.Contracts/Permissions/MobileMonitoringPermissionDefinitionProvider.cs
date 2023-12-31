﻿using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlueXT.MobileMonitoring.Permissions;

/// <summary>
/// Провайдер определений разрешений.
/// </summary>
public class MobileMonitoringPermissionDefinitionProvider : PermissionDefinitionProvider
{
    /// <summary>
    /// Определить разрешения.
    /// </summary>
    /// <param name="context">Контекст для определения разрешений.</param>
    public override void Define(IPermissionDefinitionContext context)
    {
        var deviceStatistics = context.AddGroup(MobileMonitoringPermissions.DeviceStatistics);
        deviceStatistics.AddPermission(
            MobileMonitoringPermissions.Delete,
            Localizer($"Permission:{nameof(MobileMonitoringPermissions.Delete)}"));
        deviceStatistics.AddPermission(
            MobileMonitoringPermissions.GetList,
            Localizer($"Permission:{nameof(MobileMonitoringPermissions.GetList)}"));
    }

    private static LocalizableString Localizer(string name) => LocalizableString.Create<MobileMonitoringResource>(name);
}
