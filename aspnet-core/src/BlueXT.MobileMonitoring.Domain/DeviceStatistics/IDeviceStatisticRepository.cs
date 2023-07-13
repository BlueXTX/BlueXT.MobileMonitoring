using System;
using Volo.Abp.Domain.Repositories;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Интерфейс базового репозитория для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public interface IDeviceStatisticRepository : IBasicRepository<DeviceStatistic, Guid>
{
}
