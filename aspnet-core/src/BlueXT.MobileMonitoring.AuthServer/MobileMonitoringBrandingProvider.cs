using Volo.Abp.DependencyInjection;
using Volo.Abp.Ui.Branding;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Провайдер брендинга приложения.
/// </summary>
[Dependency(ReplaceServices = true)]
public class MobileMonitoringBrandingProvider : DefaultBrandingProvider
{
    /// <summary>
    /// Название приложения.
    /// </summary>
    public override string AppName => "MobileMonitoring";
}
