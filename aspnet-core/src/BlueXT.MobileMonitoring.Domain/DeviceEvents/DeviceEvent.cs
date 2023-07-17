using System;
using Volo.Abp.Domain.Entities.Auditing;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// Событие устройства.
/// </summary>
public class DeviceEvent : FullAuditedEntity<Guid>
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Описание.
    /// </summary>
    public string? Description { get; set; } = string.Empty;
}
