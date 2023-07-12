using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Volo.Abp.ObjectMapping;

namespace BlueXT.MobileMonitoring.Mapster;

/// <summary>
/// Расширение коллекции сервисов для добавления Mapster'а.
/// </summary>
public static class MapsterServiceCollectionExtension
{
    /// <summary>
    /// Добавить маппинг с использованием Mapster.
    /// </summary>
    /// <param name="services">Коллекция сервисов.</param>
    /// <returns>Коллекция сервисов содержащая маппинг с использованием Mapster.</returns>
    public static IServiceCollection AddMapster(this IServiceCollection services)
        => services.Replace(ServiceDescriptor.Transient<IAutoObjectMappingProvider, MapsterAutoObjectMappingProvider>());
}
