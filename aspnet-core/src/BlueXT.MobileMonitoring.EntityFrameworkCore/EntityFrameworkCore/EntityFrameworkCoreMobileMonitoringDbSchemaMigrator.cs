using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using BlueXT.MobileMonitoring.Data;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

public class EntityFrameworkCoreMobileMonitoringDbSchemaMigrator
    : IMobileMonitoringDbSchemaMigrator, ITransientDependency
{
    private readonly IServiceProvider _serviceProvider;

    public EntityFrameworkCoreMobileMonitoringDbSchemaMigrator(
        IServiceProvider serviceProvider)
    {
        _serviceProvider = serviceProvider;
    }

    public async Task MigrateAsync()
    {
        /* We intentionally resolving the MobileMonitoringDbContext
         * from IServiceProvider (instead of directly injecting it)
         * to properly get the connection string of the current tenant in the
         * current scope.
         */

        await _serviceProvider
            .GetRequiredService<MobileMonitoringDbContext>()
            .Database
            .MigrateAsync();
    }
}
