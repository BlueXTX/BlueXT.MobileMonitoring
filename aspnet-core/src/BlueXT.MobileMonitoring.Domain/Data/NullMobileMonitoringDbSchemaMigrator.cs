using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.Data;

/* This is used if database provider does't define
 * IMobileMonitoringDbSchemaMigrator implementation.
 */
public class NullMobileMonitoringDbSchemaMigrator : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    public Task MigrateAsync() => Task.CompletedTask;
}
