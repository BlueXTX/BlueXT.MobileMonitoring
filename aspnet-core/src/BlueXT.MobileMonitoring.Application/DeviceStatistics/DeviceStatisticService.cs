using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

public class DeviceStatisticService : CrudAppService<DeviceStatistic, DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceStatisticDto>, IDeviceStatisticService
{
    public DeviceStatisticService(IRepository<DeviceStatistic, Guid> repository)
        : base(repository)
    {
    }
}
