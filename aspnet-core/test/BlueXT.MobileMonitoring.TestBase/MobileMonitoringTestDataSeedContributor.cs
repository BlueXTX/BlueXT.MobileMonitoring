using System.Threading.Tasks;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Сидер для тестовой базы данных.
/// </summary>
public class MobileMonitoringTestDataSeedContributor : IDataSeedContributor, ITransientDependency
{
    /// <summary>
    /// Заполнить БД тестовыми данными.
    /// </summary>
    /// <param name="context">Контекст для заполнения.</param>
    /// <returns>Задача заполнения БД.</returns>
    public Task SeedAsync(DataSeedContext context) => Task.CompletedTask;
}
