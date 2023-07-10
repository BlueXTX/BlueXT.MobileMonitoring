using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// Статистика устройства.
/// </summary>
public class DeviceStatistic : FullAuditedEntity<Guid>
{
    /// <summary>
    /// Id устройства.
    /// </summary>
    public Guid DeviceId { get; set; }

    /// <summary>
    /// Имя пользователя.
    /// </summary>
    public string Username { get; set; }

    /// <summary>
    /// Операционная система.
    /// </summary>
    public string OperatingSystem { get; set; }

    /// <summary>
    /// Версия установленного приложения.
    /// </summary>
    public string AppVersion { get; set; }
}
