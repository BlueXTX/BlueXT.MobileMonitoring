using System;
using System.Collections.Generic;
using System.Text;
using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring;

/* Inherit your application services from this class.
 */
public abstract class MobileMonitoringAppService : ApplicationService
{
    protected MobileMonitoringAppService()
    {
        LocalizationResource = typeof(MobileMonitoringResource);
    }
}
