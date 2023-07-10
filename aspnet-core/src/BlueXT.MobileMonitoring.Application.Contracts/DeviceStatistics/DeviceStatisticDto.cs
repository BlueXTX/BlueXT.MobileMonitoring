using System;
using Volo.Abp.Application.Dtos;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// DTO для DeviceStatistic/>/>
/// </summary>
public class DeviceStatisticDto : FullAuditedEntityDto<Guid>
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
