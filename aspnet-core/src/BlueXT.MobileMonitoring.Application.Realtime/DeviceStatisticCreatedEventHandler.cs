using BlueXT.MobileMonitoring.Application.Realtime.Hubs;
using BlueXT.MobileMonitoring.DeviceStatistics;
using Microsoft.AspNetCore.SignalR;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Entities.Events;
using Volo.Abp.EventBus;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.Application.Realtime;

/// <summary>
/// Обработчик события создания <see cref="DeviceStatistic"/>.
/// </summary>
public class DeviceStatisticCreatedEventHandler : ILocalEventHandler<EntityCreatedEventData<DeviceStatistic>>, ITransientDependency
{
    private readonly IHubContext<DeviceStatisticHub, IDeviceStatisticClient> _hubContext;
    private readonly IObjectMapper _mapper;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="hubContext">Контекст SignalR хаба.</param>
    /// <param name="mapper">Преобразователь объектов.</param>
    public DeviceStatisticCreatedEventHandler(IHubContext<DeviceStatisticHub, IDeviceStatisticClient> hubContext, IObjectMapper mapper)
    {
        _hubContext = hubContext;
        _mapper = mapper;
    }

    /// <summary>
    /// Обработать событие создания <see cref="DeviceStatistic"/>.
    /// </summary>
    /// <param name="eventData">Данные события.</param>
    /// <returns>Задача обработки.</returns>
    public async Task HandleEventAsync(EntityCreatedEventData<DeviceStatistic> eventData) => await _hubContext.Clients.All.ReceiveUpdate(_mapper.Map<DeviceStatistic, DeviceStatisticDto>(eventData.Entity));
}
