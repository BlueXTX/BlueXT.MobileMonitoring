using Microsoft.AspNetCore.Mvc;
using Volo.Abp.AspNetCore.Mvc;

namespace BlueXT.MobileMonitoring.Controllers;

public class HomeController : AbpController
{
    public ActionResult Index() => Redirect("~/swagger");
}
