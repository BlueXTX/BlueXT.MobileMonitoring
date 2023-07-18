using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlueXT.MobileMonitoring.HttpApi.Client.ConsoleTestApp;

/// <summary>
/// Входная точка приложения.
/// </summary>
internal static class Program
{
    private static IHostBuilder CreateHostBuilder(string[] args) =>
        Host.CreateDefaultBuilder(args)
            .AddAppSettingsSecretsJson()
            .ConfigureServices(
                (_, services) =>
                {
                    services.AddHostedService<ConsoleTestAppHostedService>();
                });

    private static async Task Main(string[] args) => await CreateHostBuilder(args).RunConsoleAsync();
}
