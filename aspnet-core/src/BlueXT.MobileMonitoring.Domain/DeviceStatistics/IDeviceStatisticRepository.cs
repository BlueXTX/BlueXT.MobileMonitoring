using System;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp.Domain.Repositories;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Интерфейс базового репозитория для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public interface IDeviceStatisticRepository : IBasicRepository<DeviceStatistic, Guid>
{
    /// <summary>
    /// Обновить сущность.
    /// </summary>
    /// <param name="id">Уникальный идентификатор.</param>
    /// <param name="entity">Данные для обновления.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Обновленная сущность.</returns>
    Task<DeviceStatistic> UpdateAsync(Guid id, DeviceStatistic entity, CancellationToken cancellationToken = default);

    /// <summary>
    /// Получить сущность <see cref="DeviceStatistic"/> по уникальному идентификатору.
    /// </summary>
    /// <param name="deviceId">Уникальный идентификатор.</param>
    /// <param name="cancellationToken">Токен отмены.</param>
    /// <returns>Сущность <see cref="DeviceStatistic"/>.</returns>
    Task<DeviceStatistic> GetByDeviceId(Guid deviceId, CancellationToken cancellationToken = default);
}
