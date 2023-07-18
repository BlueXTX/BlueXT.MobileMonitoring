using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль тестирования слоя Domain.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringEntityFrameworkCoreTestModule)
)]
public class MobileMonitoringDomainTestModule : AbpModule
{
}
