using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.AspNetCore.Mvc;

namespace BlueXT.MobileMonitoring.Controllers;

/// <summary>
/// Базовый класс контроллера.
/// </summary>
public abstract class MobileMonitoringController : AbpControllerBase
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    protected MobileMonitoringController() => LocalizationResource = typeof(MobileMonitoringResource);
}
