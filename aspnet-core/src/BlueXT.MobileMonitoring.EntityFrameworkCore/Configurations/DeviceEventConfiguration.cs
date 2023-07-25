using BlueXT.MobileMonitoring.DeviceEvents;
using BlueXT.MobileMonitoring.DeviceStatistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BlueXT.MobileMonitoring.Configurations;

/// <summary>
/// Конфигурация сущности <see cref="DeviceEvent"/> в базе данных.
/// </summary>
public class DeviceEventConfiguration : IEntityTypeConfiguration<DeviceEvent>
{
    /// <summary>
    /// Сконфигурировать сущность.
    /// </summary>
    /// <param name="builder">Объект предоставляющий API для конфигурации.</param>
    public void Configure(EntityTypeBuilder<DeviceEvent> builder)
    {
        builder.ConfigureByConvention();
        builder.ToTable(MobileMonitoringConsts.DbTablePrefix + "device_event");
        builder.Property(x => x.Id).HasColumnName("id");
        builder.Property(x => x.Name).HasColumnName("name").IsRequired().HasMaxLength(maxLength: 50);
        builder.Property(x => x.CreationDate).HasColumnName("creation_date");
        builder.Property(x => x.DeviceStatisticId).HasColumnName("device_statistic_id");
        builder.HasOne<DeviceStatistic>().WithMany(x => x.DeviceEvents).HasForeignKey(x => x.DeviceStatisticId);
    }
}
