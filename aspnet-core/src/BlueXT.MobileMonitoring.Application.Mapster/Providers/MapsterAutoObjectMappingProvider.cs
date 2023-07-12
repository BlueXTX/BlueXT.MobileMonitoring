using Mapster;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.Application.Mapster.Providers;

/// <summary>
/// Провайдер маппинга Mapster.
/// </summary>
public class MapsterAutoObjectMappingProvider : IAutoObjectMappingProvider
{
    /// <summary>
    /// Преобразовать сущность из TSource в TDestination.
    /// </summary>
    /// <param name="source">Входная сущность.</param>
    /// <typeparam name="TSource">Тип сущности которую необходимо преобразовать.</typeparam>
    /// <typeparam name="TDestination">Тип сущности в которую необходимо преобразовать.</typeparam>
    /// <returns>Преобразованная сущность.</returns>
    public TDestination Map<TSource, TDestination>(object source) => source.Adapt<TDestination>();

    /// <summary>
    /// Преобразовать сущность из TSource в TDestination.
    /// </summary>
    /// <param name="source">Входная сущность.</param>
    /// <param name="destination">Преобразованная сущность.</param>
    /// <typeparam name="TSource">Тип сущности которую необходимо преобразовать.</typeparam>
    /// <typeparam name="TDestination">Тип сущности в которую необходимо преобразовать.</typeparam>
    /// <returns>Преобразованная сущность.</returns>
    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination) => source.Adapt(destination);
}
