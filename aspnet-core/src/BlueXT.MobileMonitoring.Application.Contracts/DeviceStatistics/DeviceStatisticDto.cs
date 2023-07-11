using System;
using Volo.Abp.Application.Dtos;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// DTO для получения DeviceStatistic.
/// </summary>
public class DeviceStatisticDto
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
}
