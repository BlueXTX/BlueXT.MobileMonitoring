using BlueXT.MobileMonitoring.Application.Mapster.Extensions;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.Application.Mapster;

/// <summary>
/// Определение модуля для интеграции Mapster.
/// </summary>
public class MobileMonitoringApplicationMapsterModule : AbpModule
{
    /// <summary>
    /// Конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context) => context.Services.AddMapster();
}
