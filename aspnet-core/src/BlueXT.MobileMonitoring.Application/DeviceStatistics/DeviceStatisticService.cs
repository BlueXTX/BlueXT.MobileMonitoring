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
    public DeviceStatisticService(
        IRepository<DeviceStatistic, Guid> baseRepository,
        IObjectMapper mapper,
        IDeviceStatisticRepository repository)
        : base(baseRepository)
    {
        _mapper = mapper;
        _repository = repository;
    }

    public override async Task<DeviceStatisticDto> CreateAsync(CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.InsertAsync(entity));
    }

    public override async Task<DeviceStatisticDto> GetAsync(Guid id) => _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.GetAsync(id));

    public override async Task<PagedResultDto<DeviceStatisticDto>> GetListAsync(PagedAndSortedResultRequestDto input)
    {
        var totalCount = await _repository.GetCountAsync();
        var entities = await _repository.GetPagedListAsync(input.SkipCount, input.MaxResultCount, input.Sorting);
        var mappedEntities = _mapper.Map<List<DeviceStatistic>, List<DeviceStatisticDto>>(entities);
        return new PagedResultDto<DeviceStatisticDto>(totalCount, mappedEntities);
    }

    public override async Task<DeviceStatisticDto> UpdateAsync(Guid id, CreateOrUpdateDeviceStatisticDto input)
    {
        var entity = _mapper.Map<CreateOrUpdateDeviceStatisticDto, DeviceStatistic>(input);
        return _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await _repository.UpdateAsync(id, entity));
    }

    public override async Task DeleteAsync(Guid id) => await _repository.DeleteAsync(id);
}
