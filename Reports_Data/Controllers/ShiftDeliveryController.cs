using Microsoft.AspNetCore.Mvc;
using Reports_Data.DBContext;
using Reports_Data.Services;

namespace Reports_Data.Controllers
{
    [ApiController]
    [Route("Table/[controller]")]
    public class ShiftDeliveryController : Controller
    {
        ShiftDeliveryService shiftDeliveryService;
        public ShiftDeliveryController(StaffSalaryDBContext staffSalaryDBContext)
        {
            shiftDeliveryService = new ShiftDeliveryService(staffSalaryDBContext);
        }

        [HttpGet]
        public IActionResult ShiftDeliveryData(string shift, DateTime date1)
        {
            try
            {
                return Ok(shiftDeliveryService.ShiftDeliveryData(shift, date1));
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
            
        }
    }
}
