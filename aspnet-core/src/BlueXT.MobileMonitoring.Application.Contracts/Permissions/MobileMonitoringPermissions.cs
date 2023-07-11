namespace BlueXT.MobileMonitoring.Permissions;

/// <summary>
/// Определения разрешений.
/// </summary>
public static class MobileMonitoringPermissions
{
    /// <summary>
    /// Операции с DeviceStatistics.
    /// </summary>
    public const string DeviceStatistics = "DeviceStatistics";

    /// <summary>
    /// Удаление DeviceStatistics.
    /// </summary>
    public const string Delete = DeviceStatistics + ".Delete";

    /// <summary>
    /// Получение списка DeviceStatistics.
    /// </summary>
    public const string GetList = DeviceStatistics + ".GetList";
}
