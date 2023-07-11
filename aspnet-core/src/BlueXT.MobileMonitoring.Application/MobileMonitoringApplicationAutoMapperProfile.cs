using AutoMapper;
using BlueXT.MobileMonitoring.DeviceStatistics;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Профиль маппинга сущности <see cref="DeviceStatistic"/>.
/// </summary>
public class MobileMonitoringApplicationAutoMapperProfile : Profile
{
    /// <summary>
    /// Набор правил.
    /// </summary>
    public MobileMonitoringApplicationAutoMapperProfile()
    {
        CreateMap<DeviceStatistic, DeviceStatisticDto>();
        CreateMap<CreateUpdateDeviceStatisticDto, DeviceStatistic>();
    }
}
