using BlueXT.MobileMonitoring.EntityFrameworkCore;
using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring;

[DependsOn(
    typeof(MobileMonitoringEntityFrameworkCoreTestModule)
    )]
public class MobileMonitoringDomainTestModule : AbpModule
{

}
