using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlueXT.MobileMonitoring;

[Dependency(ReplaceServices = true)]
public class MobileMonitoringBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MobileMonitoring";
}
