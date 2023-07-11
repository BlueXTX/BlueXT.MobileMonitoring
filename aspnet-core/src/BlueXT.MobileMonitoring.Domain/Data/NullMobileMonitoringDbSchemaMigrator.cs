using System.Threading.Tasks;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.Data;

/// <summary>
/// Пустой мигратор базы данных.
/// </summary>
public class NullMobileMonitoringDbSchemaMigrator : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    /// <inheritdoc cref="IMobileMonitoringDbSchemaMigrator.MigrateAsync"/>
    public Task MigrateAsync() => Task.CompletedTask;
}
