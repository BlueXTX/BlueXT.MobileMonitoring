using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlueXT.MobileMonitoring.Permissions;

public class MobileMonitoringPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var deviceStatistics = context.AddGroup(MobileMonitoringPermissions.DeviceStatistics);
        deviceStatistics.AddPermission(
            MobileMonitoringPermissions.Delete,
            L($"Permission:{nameof(MobileMonitoringPermissions.Delete)}"));
        deviceStatistics.AddPermission(
            MobileMonitoringPermissions.GetList,
            L($"Permission:{nameof(MobileMonitoringPermissions.GetList)}"));
    }

    private static LocalizableString L(string name) => LocalizableString.Create<MobileMonitoringResource>(name);
}
