using BlueXT.MobileMonitoring.DeviceEvents;
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
        builder.ToTable(MobileMonitoringConsts.DbTablePrefix + nameof(DeviceEvent) + MobileMonitoringConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.Name).IsRequired().HasMaxLength(maxLength: 128);
        builder.Property(x => x.Description).HasMaxLength(maxLength: 512);
    }
}
