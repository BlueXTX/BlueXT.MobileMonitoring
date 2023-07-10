namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

public static class MobileMonitoringEfCoreEntityExtensionMappings
{
    public static void Configure()
    {
        MobileMonitoringGlobalFeatureConfigurator.Configure();
        MobileMonitoringModuleExtensionConfigurator.Configure();
    }
}
