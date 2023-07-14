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
    Task<DeviceStatistic> UpdateAsync(Guid id, DeviceStatistic entity, CancellationToken cancellationToken = new());
}
