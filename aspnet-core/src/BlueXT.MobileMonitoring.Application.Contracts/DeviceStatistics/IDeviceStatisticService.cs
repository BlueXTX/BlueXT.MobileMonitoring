using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Интерфейс для CRUD операций с сущностью DeviceStatistic.
/// </summary>
public interface IDeviceStatisticService : ICrudAppService<DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceStatisticDto>
{
}
