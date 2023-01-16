using Admin_Data.DataContext;
using Admin_Data.Models;
using Admin_Data.Services;
using Microsoft.AspNetCore.Mvc;

namespace Admin_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AdminLoginController : Controller
    {
        AdminLoginService adminLoginService;

        public AdminLoginController(AdminDBContext adminDBContext)
        {
            adminLoginService = new AdminLoginService(adminDBContext);
        }
        [HttpPost]
        public IActionResult AdminLogin(AdminLogin Details)
        {
            return Ok(adminLoginService.AdminLogin(Details));
        }
    }
}
