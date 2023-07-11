using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Volo.Abp.Autofac;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.DbMigrator;

/// <summary>
/// Модуль сидера базы данных.
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(MobileMonitoringEntityFrameworkCoreModule),
    typeof(MobileMonitoringApplicationContractsModule)
)]
public class MobileMonitoringDbMigratorModule : AbpModule
{
}
