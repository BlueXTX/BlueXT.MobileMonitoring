using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.DeviceStatistics;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// CRUD сервис для сущности <see cref="DeviceEvent"/>.
/// </summary>
public class DeviceEventService : CrudAppService<DeviceEvent, DeviceEventDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateDeviceEventDto>, IDeviceEventService
{
    private readonly IObjectMapper _mapper;
    private readonly IDeviceStatisticRepository _deviceStatisticRepository;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="deviceEventRepository">Репозиторий <see cref="DeviceEvent"/>.</param>
    /// <param name="mapper">Преобразователь объектов.</param>
    /// <param name="deviceStatisticRepository">Репозиторий <see cref="DeviceStatistic"/>.</param>
    public DeviceEventService(IRepository<DeviceEvent, Guid> deviceEventRepository, IObjectMapper mapper, IDeviceStatisticRepository deviceStatisticRepository)
        : base(deviceEventRepository)
    {
        _mapper = mapper;
        _deviceStatisticRepository = deviceStatisticRepository;
    }

    /// <summary>
    /// Получить список <see cref="DeviceEvent"/> по уникальному идентификатору устройства.
    /// </summary>
    /// <param name="deviceId">Уникальный идентификатор устройства.</param>
    /// <returns>Список событий устройства.</returns>
    public async Task<List<DeviceEventDto>> GetListByDeviceIdAsync(Guid deviceId)
    {
        var deviceStatistic = await _deviceStatisticRepository.GetByDeviceId(deviceId);
        return _mapper.Map<List<DeviceEvent>, List<DeviceEventDto>>(await Repository.GetListAsync(x => x.DeviceStatisticId == deviceStatistic.Id));
    }
}
