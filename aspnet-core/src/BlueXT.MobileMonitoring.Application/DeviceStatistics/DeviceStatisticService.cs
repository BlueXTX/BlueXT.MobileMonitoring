using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// CRUD сервис для сущности <see cref="DeviceStatistic"/>.
/// </summary>
public class DeviceStatisticService : CrudAppService<DeviceStatistic, DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateUpdateDeviceStatisticDto>, IDeviceStatisticService
{
    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    public DeviceStatisticService(IRepository<DeviceStatistic, Guid> repository)
        : base(repository)
    {
    }
}
