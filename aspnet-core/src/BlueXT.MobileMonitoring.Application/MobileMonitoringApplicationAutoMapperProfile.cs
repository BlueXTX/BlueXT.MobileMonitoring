using AutoMapper;
using BlueXT.MobileMonitoring.DeviceStatistics;

namespace BlueXT.MobileMonitoring;

public class MobileMonitoringApplicationAutoMapperProfile : Profile
{
    public MobileMonitoringApplicationAutoMapperProfile()
    {
        CreateMap<DeviceStatistic, DeviceStatisticDto>();
        CreateMap<CreateUpdateDeviceStatisticDto, DeviceStatistic>();
    }
}
