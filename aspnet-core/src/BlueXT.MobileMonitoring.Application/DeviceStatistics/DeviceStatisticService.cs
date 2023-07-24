using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.DeviceEvents;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.EventBus.Local;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// CRUD сервис для сущности <see cref="DeviceStatistic"/>.
/// </summary>
public class DeviceStatisticService : CrudAppService<DeviceStatistic, DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateDeviceStatisticDto>, IDeviceStatisticService
{
    private readonly IObjectMapper _mapper;
    private readonly ILocalEventBus _localEventBus;
    private readonly IDeviceStatisticRepository _deviceStatisticRepository;
    private readonly IRepository<DeviceEvent, Guid> _deviceEventRepository;

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="baseRepository">Репозиторий.</param>
    /// <param name="mapper">Преобразователь сущностей.</param>
    /// <param name="deviceStatisticRepository">Расширенный репозиторий <see cref="DeviceStatistic"/>.</param>
    /// <param name="deviceEventRepository">Репозиторий <see cref="DeviceEvent"/>.</param>
    /// <param name="localEventBus">Локальная шина событий.</param>
    public DeviceStatisticService(
        IRepository<DeviceStatistic, Guid> baseRepository,
        IObjectMapper mapper,
        IDeviceStatisticRepository deviceStatisticRepository,
        IRepository<DeviceEvent, Guid> deviceEventRepository,
        ILocalEventBus localEventBus)
        : base(baseRepository)
    {
        _mapper = mapper;
        _deviceStatisticRepository = deviceStatisticRepository;
        _deviceEventRepository = deviceEventRepository;
        _localEventBus = localEventBus;
    }

    /// <summary>
    /// Создать сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="input">DTO для создания.</param>
    /// <returns>Созданная сущность.</returns>
    public override async Task<DeviceStatisticDto> CreateAsync(CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        var insertedEntity = await _deviceStatisticRepository.InsertAsync(entity);
        await _localEventBus.PublishAsync(new EntityCreatedEventData<DeviceStatistic>(insertedEntity));
        foreach (var entityDeviceEvent in entity.DeviceEvents) entityDeviceEvent.DeviceStatisticId = insertedEntity.Id;

        await _deviceEventRepository.InsertManyAsync(entity.DeviceEvents);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(insertedEntity);
    }

    /// <summary>
    /// Получить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <returns>Найденная сущность.</returns>
    public override async Task<DeviceStatisticDto> GetAsync(Guid id) => _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _deviceStatisticRepository.GetAsync(id));

    /// <summary>
    /// Получить постраничный список сущностей <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="input">DTO с опциями для формирования списка.</param>
    /// <returns>Список сущностей.</returns>
    public override async Task<PagedResultDto<DeviceStatisticDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var totalCount = await _deviceStatisticRepository.GetCountAsync();
        var entities = await _deviceStatisticRepository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        var mappedEntities = _mapper.Map<List<DeviceStatistic>, List<DeviceStatisticDto>>(entities);
        return new PagedResultDto<DeviceStatisticDto>(totalCount, mappedEntities);
    }

    /// <summary>
    /// Обновить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <param name="input">Данные для обновления.</param>
    /// <returns>Обновленная сущность.</returns>
    public override async Task<DeviceStatisticDto> UpdateAsync(Guid id, CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _deviceStatisticRepository.UpdateAsync(id, entity));
    }

    /// <summary>
    /// Удалить сущность <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <returns>Задача удаления.</returns>
    public override async Task DeleteAsync(Guid id) => await _deviceStatisticRepository.DeleteAsync(id);

    /// <summary>
    /// Получить <see cref="DeviceStatisticDto"/> по уникальному идентификатору устройства.
    /// </summary>
    /// <param name="deviceId">Уникальный идентификатор устройства.</param>
    /// <returns>Задача получения.</returns>
    public async Task<DeviceStatisticDto> GetByDeviceId(Guid deviceId) => _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await Repository.GetAsync(x => x.DeviceId == deviceId));
}
