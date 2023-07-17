using System;
using Volo.Abp.Application.Dtos;
using Volo.Abp.Auditing;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// DTO сущности DeviceEvent.
/// </summary>
public class DeviceEventDto : IEntityDto<Guid>, IHasCreationTime
{
    /// <summary>
    /// Уникальный идентификатор.
    /// </summary>
    public Guid Id { get; set; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationTime { get; set; }

    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;
}
