using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Authorization.Permissions;
using Volo.Abp.Localization;

namespace BlueXT.MobileMonitoring.Permissions;

public class MobileMonitoringPermissionDefinitionProvider : PermissionDefinitionProvider
{
    public override void Define(IPermissionDefinitionContext context)
    {
        var myGroup = context.AddGroup(MobileMonitoringPermissions.GroupName);
        //Define your own permissions here. Example:
        //myGroup.AddPermission(MobileMonitoringPermissions.MyPermission1, L("Permission:MyPermission1"));
    }

    private static LocalizableString L(string name)
    {
        return LocalizableString.Create<MobileMonitoringResource>(name);
    }
}
