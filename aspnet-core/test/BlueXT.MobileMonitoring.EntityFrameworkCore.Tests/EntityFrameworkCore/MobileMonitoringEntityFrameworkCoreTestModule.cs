using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.Sqlite;
using Volo.Abp.Modularity;
using Volo.Abp.PermissionManagement;
using Volo.Abp.Uow;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

/// <summary>
/// Модуль тестирования слоя EntityFramework.
/// </summary>
[DependsOn(
    typeof(MobileMonitoringEntityFrameworkCoreModule),
    typeof(MobileMonitoringTestBaseModule),
    typeof(AbpEntityFrameworkCoreSqliteModule)
)]
public class MobileMonitoringEntityFrameworkCoreTestModule : AbpModule
{
    private SqliteConnection? _sqliteConnection;

    /// <summary>
    /// Сконфигурировать сервисы.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        Configure<PermissionManagementOptions>(
            options =>
            {
                options.SaveStaticPermissionsToDatabase = false;
                options.IsDynamicPermissionStoreEnabled = false;
            });
        context.Services.AddAlwaysDisableUnitOfWorkTransaction();

        ConfigureInMemorySqlite(context.Services);
    }

    /// <summary>
    /// Вызывается при закрытии приложения.
    /// </summary>
    /// <param name="context">Контекст закрытия приложения.</param>
    public override void OnApplicationShutdown(ApplicationShutdownContext context) => _sqliteConnection?.Dispose();

    private static SqliteConnection CreateDatabaseAndGetConnection()
    {
        var connection = new SqliteConnection("Data Source=:memory:");
        connection.Open();

        var options = new DbContextOptionsBuilder<MobileMonitoringDbContext>()
            .UseSqlite(connection)
            .Options;

        using var context = new MobileMonitoringDbContext(options);
        context.GetService<IRelationalDatabaseCreator>().CreateTables();

        return connection;
    }

    private void ConfigureInMemorySqlite(IServiceCollection services)
    {
        _sqliteConnection = CreateDatabaseAndGetConnection();

        services.Configure<AbpDbContextOptions>(
            options =>
            {
                options.Configure(
                    context =>
                    {
                        context.DbContextOptions.UseSqlite(_sqliteConnection);
                    });
            });
    }
}
