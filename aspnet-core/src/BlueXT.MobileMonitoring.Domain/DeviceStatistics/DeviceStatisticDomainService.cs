using System.Collections.Generic;
using System.Linq;
using BlueXT.MobileMonitoring.DeviceEvents;
using Volo.Abp.Domain.Services;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Доменный сервис для работы с <see cref="DeviceEvent"/>.
/// </summary>
public class DeviceStatisticDomainService : DomainService
{
    /// <summary>
    /// Привязать события к <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="deviceStatistic">Сущность к которой будет осуществляться привязка.</param>
    /// <param name="deviceEvents">События для привязки.</param>
    /// <returns>Список привязанных событий.</returns>
    public IEnumerable<DeviceEvent> AssignDeviceEvents(DeviceStatistic deviceStatistic, IEnumerable<DeviceEvent> deviceEvents)
    {
        var eventsToAssign = deviceEvents.ToList();
        foreach (var deviceEvent in eventsToAssign)
        {
            deviceEvent.DeviceStatisticId = deviceStatistic.Id;
        }

        return eventsToAssign;
    }
}
