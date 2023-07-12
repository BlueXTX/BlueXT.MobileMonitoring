using System;

namespace BlueXT.MobileMonitoring.Mapster;

/// <summary>
/// Исключение маппинга с использованием Mapster.
/// </summary>
public class MapsterMappingException : Exception
{
    /// <summary>
    /// Конструктор.
    /// </summary>
    public MapsterMappingException()
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    public MapsterMappingException(string message)
        : base(message)
    {
    }

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="message">Сообщение об ошибке.</param>
    /// <param name="innerException">Внутреннее исключение.</param>
    public MapsterMappingException(string message, Exception innerException)
        : base(message, innerException)
    {
    }
}
