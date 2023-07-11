using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BlueXT.MobileMonitoring.Controllers;

/// <summary>
/// Контроллер домашней страницы.
/// </summary>
public class HomeController : AbpController
{
    /// <summary>
    /// Главная страница.
    /// </summary>
    /// <returns>Страница с описанием API.</returns>
    public ActionResult Index() => Redirect("~/swagger");
}
