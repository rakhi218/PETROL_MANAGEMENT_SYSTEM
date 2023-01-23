using Microsoft.AspNetCore.Mvc;
using Reports_Data.DBContext;
using Reports_Data.Services;

namespace Reports_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PumpDailyReportController : Controller
    {
        PumpDailyService pumpDailyService;
        public PumpDailyReportController(StaffSalaryDBContext staffSalaryDBContext)
        {
            pumpDailyService = new PumpDailyService(staffSalaryDBContext);
        }

        [HttpGet]
        public IActionResult PumpDailyReport(string shift, DateTime date)
        {
            try
            {
                return Ok(pumpDailyService.GetPumpDailyReport(shift, date));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
