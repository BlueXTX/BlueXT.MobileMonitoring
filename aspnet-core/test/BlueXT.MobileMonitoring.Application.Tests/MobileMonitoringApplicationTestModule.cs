using Volo.Abp.Modularity;

namespace BlueXT.MobileMonitoring;

[DependsOn(
    typeof(MobileMonitoringApplicationModule),
    typeof(MobileMonitoringDomainTestModule)
)]
public class MobileMonitoringApplicationTestModule : AbpModule
{
}
