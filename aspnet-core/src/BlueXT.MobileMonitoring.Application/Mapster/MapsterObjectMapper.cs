using System;
using Mapster;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.Mapster;

/// <summary>
/// Маппер объектов основанный на библиотеке Mapster.
/// </summary>
public class MapsterObjectMapper : IObjectMapper, ITransientDependency
{
    /// <summary>
    /// Провайдер сервисов приложения.
    /// </summary>
    private readonly IServiceProvider _serviceProvider;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="autoObjectMappingProvider">Провайдер маппинга объектов.</param>
    /// <param name="serviceProvider">Провайдер сервисов.</param>
    public MapsterObjectMapper(IAutoObjectMappingProvider autoObjectMappingProvider, IServiceProvider serviceProvider)
    {
        AutoObjectMappingProvider = autoObjectMappingProvider;
        _serviceProvider = serviceProvider;
    }

    /// <summary>
    /// Провайдер маппинга объектов.
    /// </summary>
    public IAutoObjectMappingProvider AutoObjectMappingProvider { get; }
    
    /// <summary>
    /// Преобразовать объект в нужный тип.
    /// </summary>
    /// <param name="source">Данные для преобразования.</param>
    /// <typeparam name="TSource">Тип входного объекта.</typeparam>
    /// <typeparam name="TDestination">Тип объекта в который нужно преобразовать данные.</typeparam>
    /// <returns>Преобразованный объект.</returns>
    /// <exception cref="MapsterMappingException">Выбрасывается когда объект для преобразования равен null.</exception>
    public TDestination Map<TSource, TDestination>(TSource source)
    {
        if (source is null) throw new MapsterMappingException("Source object is null");
        var result = TryMapWithSpecificMapper<TSource, TDestination>(source);

        return result ?? AutoObjectMappingProvider.Map<TSource, TDestination>(source);
    }

    /// <summary>
    /// Преобразовать объект в нужный тип.
    /// </summary>
    /// <param name="source">Данные для преобразования.</param>
    /// <param name="destination">Объект для заполнения данных.</param>
    /// <typeparam name="TSource">Тип входного объекта.</typeparam>
    /// <typeparam name="TDestination">Тип объекта в который нужно преобразовать данные.</typeparam>
    /// <returns>Преобразованный объект.</returns>
    /// <exception cref="MapsterMappingException">Выбрасывается когда объект для преобразования равен null.</exception>
    public TDestination Map<TSource, TDestination>(TSource source, TDestination destination)
    {
        if (source is null) throw new MapsterMappingException("Source object is null");
        var result = TryMapWithSpecificMapper<TSource, TDestination>(source, destination);

        return result ?? AutoObjectMappingProvider.Map<TSource, TDestination>(source, destination);
    }

    private IObjectMapper<TSource, TDestination>? FindSpecificMapper<TSource, TDestination>()
    {
        using var scope = _serviceProvider.CreateScope();
        return scope.ServiceProvider.GetService<IObjectMapper<TSource, TDestination>>();
    }

    private TDestination? TryMapWithSpecificMapper<TSource, TDestination>(TSource source, TDestination destination)
    {
        var mapper = FindSpecificMapper<TSource, TDestination>();
        return mapper is null ? default : mapper.Map(source, destination);
    }

    private TDestination? TryMapWithSpecificMapper<TSource, TDestination>(TSource source)
    {
        var mapper = FindSpecificMapper<TSource, TDestination>();
        return mapper is null ? default : mapper.Map(source);
    }
}
