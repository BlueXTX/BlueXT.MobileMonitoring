using System;

namespace BlueXT.MobileMonitoring.DeviceEvents;

/// <summary>
/// DTO для создания или обновления DeviceEvent.
/// </summary>
public class CreateOrUpdateDeviceEventDto
{
    /// <summary>
    /// Название.
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// Уникальный идентификатор статистики устройства.
    /// </summary>
    public Guid? DeviceStatisticId { get; set; }

    /// <summary>
    /// Дата создания.
    /// </summary>
    public DateTime CreationDate { get; set; }
}
