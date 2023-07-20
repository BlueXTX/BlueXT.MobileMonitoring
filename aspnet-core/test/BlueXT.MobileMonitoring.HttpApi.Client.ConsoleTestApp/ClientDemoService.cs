using System;
using System.Threading.Tasks;
using Volo.Abp.Account;
using Volo.Abp.DependencyInjection;

namespace BlueXT.MobileMonitoring.HttpApi.Client.ConsoleTestApp;

/// <summary>
/// Демонстрационный сервис.
/// </summary>
public class ClientDemoService : ITransientDependency
{
    private readonly IProfileAppService _profileAppService;

    /// <summary>
    /// Конструктор.
    /// </summary>
    /// <param name="profileAppService">Сервис для работы с профилем.</param>
    public ClientDemoService(IProfileAppService profileAppService) => _profileAppService = profileAppService;

    /// <summary>
    /// Запустить.
    /// </summary>
    /// <returns>Запущенная задача.</returns>
    public async Task RunAsync()
    {
        var output = await _profileAppService.GetAsync();
        Console.WriteLine($"UserName : {output.UserName}");
        Console.WriteLine($"Email    : {output.Email}");
        Console.WriteLine($"Name     : {output.Name}");
        Console.WriteLine($"Surname  : {output.Surname}");
    }
}
