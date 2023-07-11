using System;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

/// <summary>
/// Мигратор схемы базы данных для Entity Framework.
/// </summary>
public class EntityFrameworkCoreMobileMonitoringDbSchemaMigrator
    : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="serviceProvider">Провайдер сервисов приложения.</param>
    public EntityFrameworkCoreMobileMonitoringDbSchemaMigrator(
        IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    /// <inheritdoc cref="IMobileMonitoringDbSchemaMigrator.MigrateAsync"/>
    public async Task MigrateAsync() =>
        await _serviceProvider
            .GetRequiredService<MobileMonitoringDbContext>()
            .Database
            .MigrateAsync();
}
