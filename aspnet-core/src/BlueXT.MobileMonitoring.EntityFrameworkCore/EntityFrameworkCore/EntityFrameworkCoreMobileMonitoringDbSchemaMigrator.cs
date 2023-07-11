using System;
using System.Threading.Tasks;
using BlueXT.MobileMonitoring.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

public class EntityFrameworkCoreMobileMonitoringDbSchemaMigrator
    : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMobileMonitoringDbSchemaMigrator(
        IServiceProvider serviceProvider) =>
        _serviceProvider = serviceProvider;

    public async Task MigrateAsync() =>
        await _serviceProvider
            .GetRequiredService<MobileMonitoringDbContext>()
            .Database
            .MigrateAsync();
}
