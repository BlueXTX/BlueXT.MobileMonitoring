using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Serilog;
using Serilog.Events;

namespace BlueXT.MobileMonitoring.DbMigrator;

/// <summary>
/// Главный класс приложения.
/// </summary>
internal class Program
{
    /// <summary>
    /// Конфигурация создателя хоста.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Создатель хоста.</returns>
    public static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddAppSettingsSecretsJson()
            .ConfigureLogging((context, logging) => logging.ClearProviders())
            .ConfigureServices(
                (hostContext, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });

    private static async Task Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .MinimumLevel.Information()
            .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            .MinimumLevel.Override("Volo.Abp", LogEventLevel.Warning)
#if DEBUG
            .MinimumLevel.Override("BlueXT.MobileMonitoring", LogEventLevel.Debug)
#else
                .MinimumLevel.Override("BlueXT.MobileMonitoring", LogEventLevel.Information)
#endif
            .Enrich.FromLogContext()
            .WriteTo.Async(c => c.File("Logs/logs.txt"))
            .WriteTo.Async(c => c.Console())
            .CreateLogger();

        await CreateHostBuilder(args).RunConsoleAsync();
    }
}
