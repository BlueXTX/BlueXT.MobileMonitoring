using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring;

public abstract class MobileMonitoringAppService : ApplicationService
{
    protected MobileMonitoringAppService() => LocalizationResource = typeof(MobileMonitoringResource);
}
