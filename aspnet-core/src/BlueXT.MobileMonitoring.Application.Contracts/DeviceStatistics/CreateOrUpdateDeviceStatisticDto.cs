using System;
using System.Collections.Generic;
using BlueXT.MobileMonitoring.DeviceEvents;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// DTO для создания DeviceStatistic.
/// </summary>
public class CreateOrUpdateDeviceStatisticDto
{
    /// <summary>
    /// Id устройства.
    /// </summary>
    public Guid DeviceId { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Username { get; set; } = string.Empty;

    /// <summary>
    /// Операционная система.
    /// </summary>
    public string OperatingSystem { get; set; } = string.Empty;

    /// <summary>
    /// Версия установленного приложения.
    /// </summary>
    public string AppVersion { get; set; } = string.Empty;

    /// <summary>
    /// Список событий устройства.
    /// </summary>
    public IReadOnlyCollection<CreateOrUpdateDeviceEventDto> DeviceEvents { get; set; } = Array.Empty<CreateOrUpdateDeviceEventDto>();
}
