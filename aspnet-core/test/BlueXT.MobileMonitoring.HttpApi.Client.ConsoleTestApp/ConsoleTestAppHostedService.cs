using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Volo.Abp;

namespace BlueXT.MobileMonitoring.HttpApi.Client.ConsoleTestApp;

/// <summary>
/// Hosted-сервис для запуска консольного тестирования.
/// </summary>
public class ConsoleTestAppHostedService : IHostedService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="configuration">Конфигурация.</param>
    public ConsoleTestAppHostedService(IConfiguration configuration) => _configuration = configuration;

    /// <summary>
    /// Запустить сервис.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Запущенная задача.</returns>
    public async Task StartAsync(CancellationToken cancellationToken)
    {
        using var application = await AbpApplicationFactory.CreateAsync<MobileMonitoringConsoleApiClientModule>(
            options =>
            {
                options.Services.ReplaceConfiguration(_configuration);
                options.UseAutofac();
            });
        await application.InitializeAsync();

        var demo = application.ServiceProvider.GetRequiredService<ClientDemoService>();
        await demo.RunAsync();

        await application.ShutdownAsync();
    }

    /// <summary>
    /// Остановить сервис.
    /// </summary>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Задача остановки сервиса.</returns>
    public Task StopAsync(CancellationToken cancellationToken) => Task.CompletedTask;
}
