﻿using System;

namespace BlueXT.MobileMonitoring.DeviceStatistics;

/// <summary>
/// DTO для создания DeviceStatistic.
/// </summary>
public class CreateUpdateDeviceStatisticDto
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
