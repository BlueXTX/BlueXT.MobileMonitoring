﻿using BlueXT.MobileMonitoring.DeviceStatistics;
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
        builder.ConfigureByConvention();
        builder.ToTable(MobileMonitoringConsts.DbTablePrefix + "device_statistic");
        builder.HasIndex(x => x.Id).IsUnique();
        builder.Property(x => x.Id).HasColumnName("id");
        builder.HasIndex(x => x.DeviceId).IsUnique();
        builder.Property(x => x.DeviceId).HasColumnName("device_id");
        builder.Property(x => x.Username).IsRequired().HasColumnName("username");
        builder.Property(x => x.OperatingSystem).IsRequired().HasColumnName("operating_system");
        builder.Property(x => x.AppVersion).IsRequired().HasColumnName("app_version");
    }
}
