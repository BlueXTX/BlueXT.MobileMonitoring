using System;
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

    /// <summary>
    /// Конструктор класса.
    /// </summary>
    /// <param name="repository">Репозиторий.</param>
    /// <param name="mapper">Преобразователь объектов.</param>
    public DeviceStatisticService(IRepository<DeviceStatistic, Guid> repository, IObjectMapper mapper)
        : base(repository) => _mapper = mapper;

    /// <summary>
    /// Получить <see cref="DeviceStatisticDto"/> по уникальному идентификатору устройства.
    /// </summary>
    /// <param name="deviceId">Уникальный идентификатор устройства.</param>
    /// <returns>Объект <see cref="DeviceStatisticDto"/>.</returns>
    public async Task<DeviceStatisticDto> GetByDeviceIdAsync(Guid deviceId)
        => _mapper.Map<DeviceStatistic, DeviceStatisticDto>(await Repository.GetAsync(x => x.DeviceId == deviceId));
}
