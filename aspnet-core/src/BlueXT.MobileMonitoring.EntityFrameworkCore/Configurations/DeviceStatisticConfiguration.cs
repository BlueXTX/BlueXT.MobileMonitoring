using BlueXT.MobileMonitoring.DeviceStatistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BlueXT.MobileMonitoring.Configurations;

/// <summary>
/// Конфигурация сущности <see cref="DeviceStatistic"/> в базе данных.
/// </summary>
public class DeviceStatisticConfiguration : IEntityTypeConfiguration<DeviceStatistic>
{
    /// <summary>
    /// Сконфигурировать сущность.
    /// </summary>
    /// <param name="builder">Объект предоставляющий API для конфигурации.</param>
    public void Configure(EntityTypeBuilder<DeviceStatistic> builder)
    {
        builder.ToTable(MobileMonitoringConsts.DbTablePrefix + nameof(DeviceStatistic) + MobileMonitoringConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.HasIndex(x => x.DeviceId);
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.OperatingSystem).IsRequired();
        builder.Property(x => x.AppVersion).IsRequired();
    }
}
