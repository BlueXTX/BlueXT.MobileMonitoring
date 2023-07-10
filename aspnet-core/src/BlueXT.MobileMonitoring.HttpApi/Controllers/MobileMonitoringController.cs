using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlueXT.MobileMonitoring.Controllers;

/* Inherit your controllers from this class.
 */
public abstract class MobileMonitoringController : AbpControllerBase
{
    protected MobileMonitoringController()
    {
        LocalizationResource = typeof(MobileMonitoringResource);
    }
}
