using Microsoft.AspNetCore.Mvc;
using Reports_Data.DBContext;
using Reports_Data.Services;
using Reports_Data.Services.Interfaces;


namespace Reports_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffSalaryController : Controller
    {
        StaffSalaryService staffSalaryService;

        public StaffSalaryController(StaffSalaryDBContext staffSalaryDBContext)
        {
            staffSalaryService = new StaffSalaryService(staffSalaryDBContext);
        }

        [HttpGet]
        public IActionResult CalculateSalary(DateTime date1, DateTime date2)
        {
            try
            {
                return Ok(staffSalaryService.CalculateSalary(date1,date2));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
