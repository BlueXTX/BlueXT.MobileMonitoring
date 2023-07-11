using System;
using System.IO;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

/// <summary>
/// Фабрика создания контекста базы данных <see cref="MobileMonitoringDbContext"/> во время миграции..
/// </summary>
public class MobileMonitoringDbContextFactory : IDesignTimeDbContextFactory<MobileMonitoringDbContext>
{
    /// <summary>
    /// Создать контекст базы данных.
    /// </summary>
    /// <param name="args">Аргументы командной строки.</param>
    /// <returns>Контекст базы данных.</returns>
    public MobileMonitoringDbContext CreateDbContext(string[] args)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

        var configuration = BuildConfiguration();

        var builder = new DbContextOptionsBuilder<MobileMonitoringDbContext>()
            .UseNpgsql(configuration.GetConnectionString("Default"));

        return new MobileMonitoringDbContext(builder.Options);
    }

    private static IConfigurationRoot BuildConfiguration()
    {
        var builder = new ConfigurationBuilder()
            .SetBasePath(Path.Combine(Directory.GetCurrentDirectory(), "../BlueXT.MobileMonitoring.DbMigrator/"))
            .AddJsonFile("appsettings.json", optional: false);

        return builder.Build();
    }
}
