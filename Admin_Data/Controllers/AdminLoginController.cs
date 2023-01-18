using Admin_Data.DataContext;
using Admin_Data.Models;
using Admin_Data.Services;
using Microsoft.AspNetCore.Mvc;
using Pump_Data.Models;

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
            try
            {
                bool status = adminLoginService.AdminLogin(Details);
                JsonResponse jsonResponse = new JsonResponse(); 
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Login Sucess";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Login failed";
                }
                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
