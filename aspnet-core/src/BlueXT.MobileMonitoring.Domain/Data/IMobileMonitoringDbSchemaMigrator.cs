using System.Threading.Tasks;

namespace BlueXT.MobileMonitoring.Data;

public interface IMobileMonitoringDbSchemaMigrator
{
    Task MigrateAsync();
}
