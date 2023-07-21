using Volo.Abp.AspNetCore.SignalR;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.Application.Realtime;

/// <summary>
/// Модуль для работы обработки данных в реальном времени.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(MobileMonitoringApplicationContractsModule),
    typeof(AbpAspNetCoreSignalRModule)
)]
public class MobileMonitoringApplicationRealtimeModule : AbpModule
{
}
