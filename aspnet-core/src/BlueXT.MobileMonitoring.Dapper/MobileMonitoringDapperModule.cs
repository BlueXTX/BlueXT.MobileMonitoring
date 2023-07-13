using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.Dapper;

[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(MobileMonitoringEntityFrameworkCoreModule)
)]
public class MobileMonitoringDapperModule : AbpModule
{
}
