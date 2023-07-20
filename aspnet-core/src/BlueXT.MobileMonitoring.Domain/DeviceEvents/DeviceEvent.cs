using System;
using Volo.Abp.Domain.Entities;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// Событие устройства.
/// </summary>
public class DeviceEvent : Entity<Guid>
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationDate { get; set; }

    /// <summary>
    /// Уникальный идентификатор устройства.
    /// </summary>
    public Guid DeviceId { get; set; }
}
