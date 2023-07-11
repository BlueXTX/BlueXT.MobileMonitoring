using System.Threading;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Volo.Abp;
using Volo.Abp.Data;

namespace BlueXT.MobileMonitoring.DbMigrator;

/// <summary>
/// Хостед-сервис мигратора базы данных.
/// </summary>
public class DbMigratorHostedService : IHostedService
{
    private readonly IHostApplicationLifetime _hostApplicationLifetime;
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="hostApplicationLifetime">Жизненный цикл хоста.</param>
    /// <param name="configuration">Конфигурация.</param>
    public DbMigratorHostedService(IHostApplicationLifetime hostApplicationLifetime, IConfiguration configuration)
    {
        _hostApplicationLifetime = hostApplicationLifetime;
        _configuration = configuration;
    }

    /// <summary>
    /// Запустить.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача запуска хоста.</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<MobileMonitoringDbMigratorModule>(
            options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.UseAutofac();
                options.Services.AddLogging(c => c.AddSerilog());
                options.AddDataMigrationEnvironment();
            });
        await application.InitializeAsync();

        await application
            .ServiceProvider
            .GetRequiredService<MobileMonitoringDbMigrationService>()
            .MigrateAsync();

        await application.ShutdownAsync();

        _hostApplicationLifetime.StopApplication();
    }

    /// <summary>
    /// Остановить.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача отмены.</returns>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
