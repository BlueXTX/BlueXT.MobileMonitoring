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
            .ConfigureLogging(
                (context, logging) =>
                {
                    logging.ClearProviders();
                    Log.Logger = new LoggerConfiguration()
                        .ReadFrom.Configuration(context.Configuration)
                        .CreateLogger();
                })
            .ConfigureServices(
                (_, services) =>
                {
                    services.AddHostedService<DbMigratorHostedService>();
                });

    private static async Task Main(string[] args) => await CreateHostBuilder(args).RunConsoleAsync();
}
