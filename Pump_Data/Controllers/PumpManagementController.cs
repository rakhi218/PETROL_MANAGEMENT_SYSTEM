using Microsoft.AspNetCore.Mvc;

namespace Pump_Data.Controllers
{
    public class PumpManagementController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
