using System;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Volo.Abp;
using Volo.Abp.Modularity;
using Volo.Abp.Testing;
using Volo.Abp.Uow;

namespace BlueXT.MobileMonitoring;

/// <summary>
/// Базовый класс для помощи в тестировании.
/// </summary>
/// <typeparam name="TStartupModule">Запускаемый модуль.</typeparam>
public abstract class MobileMonitoringTestBase<TStartupModule> : AbpIntegratedTest<TStartupModule>
    where TStartupModule : IAbpModule
{
    /// <summary>
    /// Задать опции приложения.
    /// </summary>
    /// <param name="options">Опции.</param>
    protected override void SetAbpApplicationCreationOptions(AbpApplicationCreationOptions options) => options.UseAutofac();

    /// <summary>
    /// Выполнить задачу используя unit of work.
    /// </summary>
    /// <param name="func">Функция для выполнения.</param>
    /// <returns>Выполняемая задача.</returns>
    protected virtual Task WithUnitOfWorkAsync(Func<Task> func) => WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);

    /// <summary>
    /// Выполнить задачу используя unit of work.
    /// </summary>
    /// <param name="options">Настройки UOW.</param>
    /// <param name="action">Задача для выполнения.</param>
    /// <returns>Выполняемая задача.</returns>
    protected virtual async Task WithUnitOfWorkAsync(AbpUnitOfWorkOptions options, Func<Task> action)
    {
        using var scope = ServiceProvider.CreateScope();
        var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

        using var uow = uowManager.Begin(options);
        await action();

        await uow.CompleteAsync();
    }

    /// <summary>
    /// Выполнить задачу используя unit of work.
    /// </summary>
    /// <param name="func">Задача для выполнения.</param>
    /// <returns>Выполняемая задача.</returns>
    protected virtual Task<TResult> WithUnitOfWorkAsync<TResult>(Func<Task<TResult>> func) => WithUnitOfWorkAsync(new AbpUnitOfWorkOptions(), func);

    /// <summary>
    /// Выполнить задачу используя unit of work.
    /// </summary>
    /// <param name="options">Настройки UOW.</param>
    /// <param name="func">Задача для выполнения.</param>
    /// <returns>Выполняемая задача.</returns>
    protected virtual async Task<TResult> WithUnitOfWorkAsync<TResult>(AbpUnitOfWorkOptions options, Func<Task<TResult>> func)
    {
        using var scope = ServiceProvider.CreateScope();
        var uowManager = scope.ServiceProvider.GetRequiredService<IUnitOfWorkManager>();

        using var uow = uowManager.Begin(options);
        var result = await func();
        await uow.CompleteAsync();
        return result;
    }
}
