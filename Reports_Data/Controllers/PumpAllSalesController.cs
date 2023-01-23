using Microsoft.AspNetCore.Mvc;
using Reports_Data.DBContext;
using Reports_Data.Services;

namespace Reports_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PumpAllSalesController : Controller
    {
        PumpAllSalesService pumpAllSalesService;

        public PumpAllSalesController(StaffSalaryDBContext staffSalaryDBContext)
        {
            pumpAllSalesService = new PumpAllSalesService(staffSalaryDBContext);
        }

        [HttpGet]
        public IActionResult GetPumpSalesById(int id)
        {
            try
            {
                return Ok(pumpAllSalesService.GetPumpSalesById(id));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
