using BlueXT.MobileMonitoring.DeviceStatistics;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Volo.Abp.EntityFrameworkCore.Modeling;

namespace BlueXT.MobileMonitoring.Configurations;

public class DeviceStatisticConfiguration : IEntityTypeConfiguration<DeviceStatistic>
{
    public void Configure(EntityTypeBuilder<DeviceStatistic> builder)
    {
        builder.ToTable(MobileMonitoringConsts.DbTablePrefix + nameof(DeviceStatistic) + MobileMonitoringConsts.DbSchema);
        builder.ConfigureByConvention();
        builder.Property(x => x.DeviceId).IsRequired();
        builder.Property(x => x.Username).IsRequired();
        builder.Property(x => x.OperatingSystem).IsRequired();
        builder.Property(x => x.AppVersion).IsRequired();
    }
}
