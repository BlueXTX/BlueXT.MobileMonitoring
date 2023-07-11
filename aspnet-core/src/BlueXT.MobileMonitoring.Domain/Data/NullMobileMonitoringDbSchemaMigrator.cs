using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.Data;

/// <summary>
/// Мигратор базы данных.
/// </summary>
public class NullMobileMonitoringDbSchemaMigrator : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    /// <summary>
    /// Мигрировать базу данных.
    /// </summary>
    /// <returns>Задача по миграции.</returns>
    public Task MigrateAsync() => Task.CompletedTask;
}
