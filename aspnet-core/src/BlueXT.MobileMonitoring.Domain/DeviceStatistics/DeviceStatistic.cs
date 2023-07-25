using System;
using System.Collections.Generic;
using BlueXT.MobileMonitoring.DeviceEvents;
using Volo.Abp.Domain.Entities;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Статистика устройства.
/// </summary>
public class DeviceStatistic : Entity<Guid>
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
    /// Список событий приложения.
    /// </summary>
    public IReadOnlyCollection<DeviceEvent> DeviceEvents { get; set; } = Array.Empty<DeviceEvent>();
}
