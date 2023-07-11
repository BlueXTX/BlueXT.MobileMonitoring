using System;
using System.IO;
using System.Linq;
using BlueXT.MobileMonitoring.EntityFrameworkCore;
using BlueXT.MobileMonitoring.Localization;
using Localization.Resources.AbpUi;
using Medallion.Threading;
using Medallion.Threading.Redis;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.DataProtection;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using StackExchange.Redis;
using Volo.Abp;
using Volo.Abp.Account;
using Volo.Abp.Account.Web;
using Volo.Abp.AspNetCore.Mvc.UI.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.LeptonXLite.Bundling;
using Volo.Abp.AspNetCore.Mvc.UI.Theme.Shared;
using Volo.Abp.AspNetCore.Serilog;
using Volo.Abp.Auditing;
using Volo.Abp.Autofac;
using Volo.Abp.BackgroundJobs;
using Volo.Abp.Caching;
using Volo.Abp.Caching.StackExchangeRedis;
using Volo.Abp.DistributedLocking;
using Volo.Abp.Localization;
using Volo.Abp.Modularity;
using Volo.Abp.UI.Navigation.Urls;
using Volo.Abp.VirtualFileSystem;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Модуль сервиса аутентификации.
/// </summary>
[DependsOn(
    typeof(AbpAutofacModule),
    typeof(AbpCachingStackExchangeRedisModule),
    typeof(AbpDistributedLockingModule),
    typeof(AbpAccountWebOpenIddictModule),
    typeof(AbpAccountApplicationModule),
    typeof(AbpAccountHttpApiModule),
    typeof(AbpAspNetCoreMvcUiLeptonXLiteThemeModule),
    typeof(MobileMonitoringEntityFrameworkCoreModule),
    typeof(AbpAspNetCoreSerilogModule)
)]
public class MobileMonitoringAuthServerModule : AbpModule
{
    /// <summary>
    /// Конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void ConfigureServices(ServiceConfigurationContext context)
    {
        var hostingEnvironment = context.Services.GetHostingEnvironment();
        var configuration = context.Services.GetConfiguration();

        ConfigureLocalizationOptions();
        ConfigureBundlingOptions();
        ConfigureAuditingOptions();
        ConfigureUrls(configuration);
        ConfigureBackgroundJobOptions();
        ConfigureDistributedCacheOptions();
        ConfigureCors(context, configuration);

        if (hostingEnvironment.IsDevelopment()) ReplaceEmbeddedFilesByPhysical(hostingEnvironment);

        ConfigureDataProtection(context, hostingEnvironment, configuration);
        ConfigureDistributedLockProvider(context, configuration);
    }

    /// <summary>
    /// Предварительная конфигурация сервисов.
    /// </summary>
    /// <param name="context">Контекст конфигурации.</param>
    public override void PreConfigureServices(ServiceConfigurationContext context) =>
        PreConfigure<OpenIddictBuilder>(
            builder =>
            {
                builder.AddValidation(
                    options =>
                    {
                        options.AddAudiences("MobileMonitoring");
                        options.UseLocalServer();
                        options.UseAspNetCore();
                    });
            });

    /// <summary>
    /// Инициализация приложения.
    /// </summary>
    /// <param name="context">Контекст инициализации.</param>
    public override void OnApplicationInitialization(ApplicationInitializationContext context)
    {
        var app = context.GetApplicationBuilder();
        var env = context.GetEnvironment();

        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseAbpRequestLocalization();

        if (!env.IsDevelopment())
        {
            app.UseErrorPage();
        }

        app.UseCorrelationId();
        app.UseStaticFiles();
        app.UseRouting();
        app.UseCors();
        app.UseAuthentication();
        app.UseAbpOpenIddictValidation();

        app.UseUnitOfWork();
        app.UseAuthorization();
        app.UseAuditing();
        app.UseAbpSerilogEnrichers();
        app.UseConfiguredEndpoints();
    }

    private static void ConfigureDataProtection(
        ServiceConfigurationContext context,
        IWebHostEnvironment hostingEnvironment,
        IConfiguration configuration)
    {
        var dataProtectionBuilder = ConfigureApplicationName(context);
        if (hostingEnvironment.IsDevelopment()) return;
        
        var redisConnection = ConnectionMultiplexer.Connect(configuration["Redis:Configuration"]);
        dataProtectionBuilder.PersistKeysToStackExchangeRedis(redisConnection, "MobileMonitoring-Protection-Keys");
    }

    private static IDataProtectionBuilder ConfigureApplicationName(ServiceConfigurationContext context) => context.Services.AddDataProtection().SetApplicationName("MobileMonitoring");

    private static void ConfigureDistributedLockProvider(ServiceConfigurationContext context, IConfiguration configuration) =>
        context.Services.AddSingleton<IDistributedLockProvider>(
            _ =>
            {
                var connection = ConnectionMultiplexer
                    .Connect(configuration["Redis:Configuration"]);
                return new RedisDistributedSynchronizationProvider(connection.GetDatabase());
            });

    private static void ConfigureCors(ServiceConfigurationContext context, IConfiguration configuration) =>
        context.Services.AddCors(
            options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder
                            .WithOrigins(
                                configuration["App:CorsOrigins"]?
                                    .Split(",", StringSplitOptions.RemoveEmptyEntries)
                                    .Select(o => o.RemovePostFix("/"))
                                    .ToArray() ?? Array.Empty<string>()
                            )
                            .WithAbpExposedHeaders()
                            .SetIsOriginAllowedToAllowWildcardSubdomains()
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                    });
            });

    private void ReplaceEmbeddedFilesByPhysical(IWebHostEnvironment hostingEnvironment) =>
        Configure<AbpVirtualFileSystemOptions>(
            options =>
            {
                options.FileSets.ReplaceEmbeddedByPhysical<MobileMonitoringDomainSharedModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}BlueXT.MobileMonitoring.Domain.Shared"));
                options.FileSets.ReplaceEmbeddedByPhysical<MobileMonitoringDomainModule>(
                    Path.Combine(
                        hostingEnvironment.ContentRootPath,
                        $"..{Path.DirectorySeparatorChar}BlueXT.MobileMonitoring.Domain"));
            });

    private void ConfigureDistributedCacheOptions() =>
        Configure<AbpDistributedCacheOptions>(
            options => { options.KeyPrefix = "MobileMonitoring:"; });

    private void ConfigureBackgroundJobOptions() =>
        Configure<AbpBackgroundJobOptions>(
            options => { options.IsJobExecutionEnabled = false; });

    private void ConfigureUrls(IConfiguration configuration) =>
        Configure<AppUrlOptions>(
            options =>
            {
                options.Applications["MVC"].RootUrl = configuration["App:SelfUrl"];
                options.RedirectAllowedUrls.AddRange(
                    configuration["App:RedirectAllowedUrls"]?.Split(separator: ',') ??
                    Array.Empty<string>());

                options.Applications["Angular"].RootUrl = configuration["App:ClientUrl"];
                options.Applications["Angular"].Urls[AccountUrlNames.PasswordReset] = "account/reset-password";
            });

    private void ConfigureAuditingOptions() =>
        Configure<AbpAuditingOptions>(
            options =>
            {
                options.ApplicationName = "AuthServer";
            });

    private void ConfigureBundlingOptions() =>
        Configure<AbpBundlingOptions>(
            options =>
            {
                options.StyleBundles.Configure(
                    LeptonXLiteThemeBundles.Styles.Global,
                    bundle => { bundle.AddFiles("/global-styles.css"); }
                );
            });

    private void ConfigureLocalizationOptions() =>
        Configure<AbpLocalizationOptions>(
            options =>
            {
                options.Resources
                    .Get<MobileMonitoringResource>()
                    .AddBaseTypes(
                        typeof(AbpUiResource)
                    );
            });
}
