using Volo.Abp.Ui.Branding;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring;

[Dependency(ReplaceServices = true)]
public class MobileMonitoringBrandingProvider : DefaultBrandingProvider
{
    public override string AppName => "MobileMonitoring";
}
