using BlueXT.MobileMonitoring.DeviceStatistics;
using Volo.Abp.AspNetCore.SignalR;

namespace BlueXT.MobileMonitoring.Application.Realtime.Hubs;

/// <summary>
/// Хаб для работы с <see cref="DeviceStatistic"/>.
/// </summary>
public class DeviceStatisticHub : AbpHub<IDeviceStatisticClient>
{
}
