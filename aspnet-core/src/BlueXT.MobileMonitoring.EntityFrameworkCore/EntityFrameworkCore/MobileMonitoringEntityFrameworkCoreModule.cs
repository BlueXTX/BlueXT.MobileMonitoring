using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.EntityFrameworkCore.PostgreSql;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.Modularity;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;
using Volo.Abp.Uow;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

[DependsOn(
    typeof(MobileMonitoringDomainModule),
    typeof(AbpIdentityEntityFrameworkCoreModule),
    typeof(AbpOpenIddictEntityFrameworkCoreModule),
    typeof(AbpPermissionManagementEntityFrameworkCoreModule),
    typeof(AbpSettingManagementEntityFrameworkCoreModule),
    typeof(AbpEntityFrameworkCorePostgreSqlModule),
    typeof(AbpBackgroundJobsEntityFrameworkCoreModule),
    typeof(AbpAuditLoggingEntityFrameworkCoreModule)
)]
public class MobileMonitoringEntityFrameworkCoreModule : AbpModule
{
    public override void PreConfigureServices(ServiceConfigurationContext context)
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", isEnabled: true);

        MobileMonitoringEfCoreEntityExtensionMappings.Configure();
    }

    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var configuration = context.Services.GetConfiguration();

        context.Services.AddAbpDbContext<MobileMonitoringDbContext>(
            options =>
            {
                options.AddDefaultRepositories(includeAllEntities: true);
            });

        var useInMemoryDatabase = configuration.GetValue<bool>("UseInMemoryDatabase");

        if (useInMemoryDatabase)
        {
            ConfigureInMemoryDatabase();
        }
        else
        {
            ConfigureNpgsqlDatabase();
        }
    }

    private void ConfigureNpgsqlDatabase() =>
        Configure<AbpDbContextOptions>(
            options =>
            {
                options.UseNpgsql();
            });

    private void ConfigureInMemoryDatabase()
    {
        Configure<AbpDbContextOptions>(
            options =>
            {
                options.Configure(
                    configurationContext =>
                    {
                        configurationContext.DbContextOptions.UseInMemoryDatabase("MobileMonitoringDb");
                    });
            });

        Configure<AbpUnitOfWorkDefaultOptions>(
            options => { options.TransactionBehavior = UnitOfWorkTransactionBehavior.Disabled; });

        Configure<AbpUnitOfWorkOptions>(
            options => { options.IsTransactional = false; });
    }
}
