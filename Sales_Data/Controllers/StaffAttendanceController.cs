using Microsoft.AspNetCore.Mvc;
using Sales_Data.DataContext;
using Sales_Data.Models;
using Pump_Data.Models;
using Sales_Data.Services;
using NLog;
using ILogger = NLog.ILogger;

namespace Sales_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffAttendanceController : Controller
    {
        StaffAttaindanceService staffAttaindanceService;

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public StaffAttendanceController(SalesDBContext salesDBContext)
        {
            staffAttaindanceService = new StaffAttaindanceService(salesDBContext);
        }

        [HttpPost]
        public IActionResult GetStaffEntry(PumpDetails details)
        {
            Console.WriteLine(details.ToString());
            DateTime dateTime = details.tblDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            try
            {
                return Ok(staffAttaindanceService.GetStaffEntry(details.tblStaffId, dateTime));
            }
            catch (Exception ex)
            {
                logger.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("deleteStaff")]
        public IActionResult RemoveStaffEntry(PumpDetails details) 
        {
            Console.WriteLine(details.ToString());
            DateTime dateTime = details.tblDate.ToDateTime(TimeOnly.Parse("10:00PM"));
            try
            {
                bool status = staffAttaindanceService.RemoveStaffEntry(details.tblStaffId, dateTime);
                JsonResponse jsonResponse = new JsonResponse();
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Deleted Successfully";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Deletion Failed";
                }
                return Ok(jsonResponse);
            }catch(Exception ex)
            {
                logger.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

    }
}
