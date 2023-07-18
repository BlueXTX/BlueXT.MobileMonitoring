using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль для тестирования слоя Application.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringApplicationModule),
    typeof(MobileMonitoringDomainTestModule)
)]
public class MobileMonitoringApplicationTestModule : AbpModule
{
}
