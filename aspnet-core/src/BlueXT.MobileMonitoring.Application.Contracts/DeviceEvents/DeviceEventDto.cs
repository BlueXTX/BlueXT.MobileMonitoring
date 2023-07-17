using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// DTO сущности DeviceEvent.
/// </summary>
public class DeviceEventDto : EntityDto<Guid>, IHasCreationTime
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationTime { get; set; }
}
