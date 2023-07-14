using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Application.Services;
using Volo.Abp.Domain.Repositories;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// CRUD сервис для сущности <see cref="DeviceStatistic"/>.
/// </summary>
public class DeviceStatisticService : CrudAppService<DeviceStatistic, DeviceStatisticDto, Guid, PagedAndSortedResultRequestDto, CreateOrUpdateDeviceStatisticDto>, IDeviceStatisticService
{
    private readonly IObjectMapper _mapper;
    private readonly IDeviceStatisticRepository _repository;

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="baseRepository">Репозиторий.</param>
    /// <param name="mapper">Преобразователь сущностей.</param>
    /// <param name="repository">Репозиторий.</param>
    public DeviceStatisticService(
        IRepository<DeviceStatistic, Guid> baseRepository,
        IObjectMapper mapper,
        IDeviceStatisticRepository repository)
        : base(baseRepository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    /// <summary>
    /// Создать сущность.
    /// </summary>
    /// <param name="input">DTO для создания.</param>
    /// <returns>Созданная сущность.</returns>
    public override async Task<DeviceStatisticDto> CreateAsync(CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.InsertAsync(entity));
    }

    /// <summary>
    /// Получить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <returns>Найденная сущность.</returns>
    public override async Task<DeviceStatisticDto> GetAsync(Guid id) => _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.GetAsync(id));

    /// <summary>
    /// Получить постраничный список сущностей.
    /// </summary>
    /// <param name="input">DTO с опциями для формирования списка.</param>
    /// <returns>Список сущностей.</returns>
    public override async Task<PagedResultDto<DeviceStatisticDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var totalCount = await _repository.GetCountAsync();
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        var mappedEntities = _mapper.Map<List<DeviceStatistic>, List<DeviceStatisticDto>>(entities);
        return new PagedResultDto<DeviceStatisticDto>(totalCount, mappedEntities);
    }

    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <param name="input">Данные для обновления.</param>
    /// <returns>Обновленная сущность.</returns>
    public override async Task<DeviceStatisticDto> UpdateAsync(Guid id, CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.UpdateAsync(id, entity));
    }

    /// <summary>
    /// Удалить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор сущности.</param>
    /// <returns>Задача удаления.</returns>
    public override async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
