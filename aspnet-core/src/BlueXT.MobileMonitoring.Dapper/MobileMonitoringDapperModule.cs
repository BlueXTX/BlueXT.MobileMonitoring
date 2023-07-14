using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Dapper;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring.Dapper;

[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(MobileMonitoringEntityFrameworkCoreModule)
)]
public class MobileMonitoringDapperModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context) => DefaultTypeMap.MatchNamesWithUnderscores = true;
}
