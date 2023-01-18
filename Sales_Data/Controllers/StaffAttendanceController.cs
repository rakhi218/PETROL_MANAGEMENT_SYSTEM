using Microsoft.AspNetCore.Mvc;
using Sales_Data.DataContext;
using Sales_Data.Models;
using Pump_Data.Models;
using Sales_Data.Services;

namespace Sales_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StaffAttendanceController : Controller
    {
        StaffAttaindanceService staffAttaindanceService;
        public StaffAttendanceController(SalesDBContext salesDBContext)
        {
            staffAttaindanceService = new StaffAttaindanceService(salesDBContext);
        }

        [HttpGet]
        public IActionResult GetStaffEntry(string tblStaffId,DateTime tblDate)
        {
            try
            {
                return Ok(staffAttaindanceService.GetStaffEntry(tblStaffId, tblDate));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult RemoveStaffEntry(string tblStaffId,DateTime tblDate) 
        {
            bool status = staffAttaindanceService.RemoveStaffEntry(tblStaffId, tblDate);
            try
            {
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
                return BadRequest(ex.Message);
            }
        }

    }
}
