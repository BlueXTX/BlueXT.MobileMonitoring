using System;
using Volo.Abp.Application.Dtos;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// DTO сущности DeviceEvent.
/// </summary>
public class DeviceEventDto : EntityDto<Guid>
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationDate { get; set; }
}
