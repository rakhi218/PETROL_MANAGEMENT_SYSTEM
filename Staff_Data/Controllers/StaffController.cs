using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Staff_Data.DataContext;
using Staff_Data.Models;
using Staff_Data.Services;

namespace Staff_Data.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class StaffController : Controller
    {

        private StaffService staffService;
        public StaffController(StaffDBContext dbContext)
        {
            staffService = new StaffService(dbContext);
        }

        [HttpGet]
        public IActionResult GetStaff()
        {
            return Ok(staffService.GetStaff());
        }

        [HttpPost]
        public IActionResult AddStaff(Staff staff)
        {
            return Ok(staffService.AddStaff(staff));
        }

        [HttpPut]
        public IActionResult UpdateStaff(Staff staff)
        {

            if (staffService.UpdateStaff(staff))
            {
                return Ok();
            }
            return NotFound();

        }

        [HttpPost]
        [Route("retrench/{id}")]
        public IActionResult RetrenchStaff([FromRoute] string id)
        {
            if (staffService.RetrenchStaff(id))
            {
                return Ok();
            }
            return NotFound();
        }

        [HttpPost]
        [Route("suspend/{id}")]
        public IActionResult SuspendStaff([FromRoute] string id)
        {
            if (staffService.SuspendStaff(id))
            {
                return Ok();
            }
            return NotFound();

        }

        [HttpPost]
        [Route("recallRetrench/{id}")]
        public IActionResult RecallRetrenchStaff([FromRoute] string id)
        {
            if (staffService.RecallRetrenchStaff(id))
            {
                return Ok();
            }
            return NotFound();

        }

        [HttpPost]
        [Route("recallSuspend/{id}")]
        public IActionResult RecallSuspendStaff([FromRoute] string id)
        {
            if (staffService.RecallSuspendStaff(id))
            {
                return Ok();
            }
            return NotFound();

        }

        [HttpGet]
        [Route("getSuspendedStaffs")]
        public IActionResult GetSuspendedStaff()
        {
            return Ok(staffService.GetSuspendedStaff());
        }

        [HttpGet]
        [Route("getRetrenchedStaffs")]
        public IActionResult GetRetrenchedStaff()
        {
            return Ok(staffService.GetRetrenchedStaff());
        }
    }


}
