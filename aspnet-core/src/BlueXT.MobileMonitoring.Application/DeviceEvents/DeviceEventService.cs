using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// CRUD сервис для сущности <see cref="DeviceEvent"/>.
/// </summary>
public class DeviceEventService : CrudAppService<DeviceEvent, DeviceEventDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateDeviceEventDto>, IDeviceEventService
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="repository">Репозиторий сущностей.</param>
    public DeviceEventService(IRepository<DeviceEvent, Guid> repository)
        : base(repository)
    {
    }
}
