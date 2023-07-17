using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// Интерфейс для работы с DeviceEvent.
/// </summary>
public interface IDeviceEventService : ICrudAppService<DeviceEventDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateDeviceEventDto>
{
}
