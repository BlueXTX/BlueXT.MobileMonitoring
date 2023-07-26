using BlueXT.MobileMonitoring.DeviceStatistics;

namespace BlueXT.MobileMonitoring.Application.Realtime.Hubs;

/// <summary>
/// Клиент для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public interface IDeviceStatisticClient
{
    /// <summary>
    /// Получить новый <see cref="DeviceStatisticDto"/>.
    /// </summary>
    /// <param name="deviceStatisticDto">ДТО.</param>
    /// <returns>Задача получения.</returns>
    Task ReceiveUpdate(DeviceStatisticDto deviceStatisticDto);
}
