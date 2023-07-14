using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Главный класс приложения.
/// </summary>
public class Program
{
    /// <summary>
    /// Входная точка.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Задача возвращающая код работы приложения.</returns>
    public static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            Log.Information("Starting BlueXT.MobileMonitoring.AuthServer.");

            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();
            await builder.AddApplicationAsync<MobileMonitoringAuthServerModule>();

            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException) throw;
            Log.Fatal(ex, "BlueXT.MobileMonitoring.AuthServer terminated unexpectedly!");
        }
        finally
        {
            await Log.CloseAndFlushAsync();
        }
    }
}
