using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Dapper;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.Dapper;

/// <summary>
/// Модуль для работы с Dapper.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(MobileMonitoringEntityFrameworkCoreModule)
)]
public class MobileMonitoringDapperModule : AbpModule
{
    /// <summary>
    /// Предварительная конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void PreConfigureServices(ServiceConfigurationContext context) => DefaultTypeMap.MatchNamesWithUnderscores = true;
}
