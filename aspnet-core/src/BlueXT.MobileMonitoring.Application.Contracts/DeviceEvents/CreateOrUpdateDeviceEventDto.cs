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
    /// Описание.
    /// </summary>
    public string? Description { get; set; } = string.Empty;
}
