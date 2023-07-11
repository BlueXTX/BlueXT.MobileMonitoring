using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Events;

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
    /// <returns>Задача выполняющая приложение.</returns>
    public static async Task Main(string[] args)
    {
        try
        {
            var builder = WebApplication.CreateBuilder(args);
            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(builder.Configuration)
                .CreateLogger();

            Log.Information("Starting BlueXT.MobileMonitoring.HttpApi.Host.");

            builder.Host.AddAppSettingsSecretsJson()
                .UseAutofac()
                .UseSerilog();

            await builder.AddApplicationAsync<MobileMonitoringHttpApiHostModule>();
            var app = builder.Build();
            await app.InitializeApplicationAsync();
            await app.RunAsync();
        }
        catch (Exception ex)
        {
            if (ex is HostAbortedException)
            {
                throw;
            }

            Log.Fatal(ex, "Host terminated unexpectedly!");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
