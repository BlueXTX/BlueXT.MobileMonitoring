using System.Threading.Tasks;

namespace BlueXT.MobileMonitoring.Data;

/// <summary>
/// Интерфейс мигратора схемы базы данных.
/// </summary>
public interface IMobileMonitoringDbSchemaMigrator
{
    /// <summary>
    /// Провести миграцию.
    /// </summary>
    /// <returns>Задача миграции.</returns>
    Task MigrateAsync();
}
