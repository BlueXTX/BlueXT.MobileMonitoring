using System.Reflection;
using BlueXT.MobileMonitoring.DeviceStatistics;
using Microsoft.EntityFrameworkCore;
using Volo.Abp.AuditLogging.EntityFrameworkCore;
using Volo.Abp.BackgroundJobs.EntityFrameworkCore;
using Volo.Abp.Data;
using Volo.Abp.DependencyInjection;
using Volo.Abp.EntityFrameworkCore;
using Volo.Abp.Identity;
using Volo.Abp.Identity.EntityFrameworkCore;
using Volo.Abp.OpenIddict.EntityFrameworkCore;
using Volo.Abp.PermissionManagement.EntityFrameworkCore;
using Volo.Abp.SettingManagement.EntityFrameworkCore;

namespace BlueXT.MobileMonitoring.EntityFrameworkCore;

/// <summary>
/// Контекст для доступа к сущностям приложения.
/// </summary>
[ReplaceDbContext(typeof(IIdentityDbContext))]
[ConnectionStringName("Default")]
public class MobileMonitoringDbContext :
    AbpDbContext<MobileMonitoringDbContext>,
    IIdentityDbContext
{
    /// <summary>
    /// Конструктор
    /// </summary>
    /// <param name="options">Опции подключения к базе данных.</param>
    public MobileMonitoringDbContext(DbContextOptions<MobileMonitoringDbContext> options)
        : base(options)
    {
    }

    /// <summary>
    /// Статистики устройств.
    /// </summary>
    public DbSet<DeviceStatistic> DeviceStatistics { get; set; } = null!;

    /// <summary>
    /// Пользователи.
    /// </summary>
    public DbSet<IdentityUser> Users { get; set; } = null!;

    /// <summary>
    /// Роли.
    /// </summary>
    public DbSet<IdentityRole> Roles { get; set; } = null!;

    /// <summary>
    /// Типы клеймов.
    /// </summary>
    public DbSet<IdentityClaimType> ClaimTypes { get; set; } = null!;

    /// <summary>
    /// Организации.
    /// </summary>
    public DbSet<OrganizationUnit> OrganizationUnits { get; set; } = null!;

    /// <summary>
    /// Логи безопасности.
    /// </summary>
    public DbSet<IdentitySecurityLog> SecurityLogs { get; set; } = null!;

    /// <summary>
    /// Связи пользователей.
    /// </summary>
    public DbSet<IdentityLinkUser> LinkUsers { get; set; } = null!;

    /// <summary>
    /// Делегирование пользователей.
    /// </summary>
    public DbSet<IdentityUserDelegation> UserDelegations { get; set; } = null!;

    /// <summary>
    /// Применение конфигураций.
    /// </summary>
    /// <param name="builder">Объект предоставляющий API для конфигурации.</param>
    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.ConfigurePermissionManagement();
        builder.ConfigureSettingManagement();
        builder.ConfigureBackgroundJobs();
        builder.ConfigureAuditLogging();
        builder.ConfigureIdentity();
        builder.ConfigureOpenIddict();

        builder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
