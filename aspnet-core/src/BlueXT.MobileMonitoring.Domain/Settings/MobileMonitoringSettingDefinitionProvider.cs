using Volo.Abp.Settings;

namespace BlueXT.MobileMonitoring.Settings;

public class MobileMonitoringSettingDefinitionProvider : SettingDefinitionProvider
{
    public override void Define(ISettingDefinitionContext context)
    {
        //Define your own settings here. Example:
        //context.Add(new SettingDefinition(MobileMonitoringSettings.MySetting1));
    }
}
