using BlueXT.MobileMonitoring.Localization;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Базовый класс для сервисов приложения MobileMonitoringApp.
/// </summary>
public abstract class MobileMonitoringAppService : ApplicationService
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    protected MobileMonitoringAppService() => LocalizationResource = typeof(MobileMonitoringResource);
}
