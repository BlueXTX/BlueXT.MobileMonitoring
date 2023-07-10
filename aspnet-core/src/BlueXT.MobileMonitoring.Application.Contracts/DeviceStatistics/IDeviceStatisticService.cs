using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

public interface IDeviceStatisticService : ICrudAppService<DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceStatisticDto>
{
}
