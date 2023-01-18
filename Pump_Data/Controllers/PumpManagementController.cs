using Microsoft.AspNetCore.Mvc;
using Pump_Data.DataContext;
using Pump_Data.Models;
using Pump_Data.Services;

namespace Pump_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PumpManagementController : Controller
    {
        PumpManagementService pumpManagementService;

        public PumpManagementController(PumpDBContext pumpDBContext)
        {
            pumpManagementService = new PumpManagementService(pumpDBContext);
        }

        [HttpGet]
        public IActionResult GetAllPumps()
        {
            try
            {
                return Ok(pumpManagementService.GetAllPumps());
            }
            catch
            {
                return BadRequest("Failed to get the data of all the pumps");
            }
        }

        [HttpPost]
        public IActionResult CreatePump(PumpManagement Pump)
        {
            try
            {
                bool status = pumpManagementService.CreatePump(Pump);
                JsonResponse jsonResponse= new JsonResponse();
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Pump Added Successfully";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Pump Addition Failed";
                }
                return Ok(jsonResponse);
            }
            catch
            {
                return BadRequest("Creation of new pump failed");
            }
        }

        [HttpPut]
        public IActionResult UpdatePump(short PumpId,PumpManagement NewPump)
        {
            try
            {
                bool status = pumpManagementService.UpdatePump(PumpId, NewPump);
                JsonResponse jsonResponse = new JsonResponse();
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Pump Updated Successfully";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Pump with Id" + PumpId + "Is Not Present";
                }
                return Ok(jsonResponse);
            }
            catch
            {
                return BadRequest("Update Failed");
            }
        }

        [HttpDelete]
        public IActionResult DeletePump(short PumpId)
        {
            try
            {
                bool status = pumpManagementService.DeletePump(PumpId);
                JsonResponse jsonResponse = new JsonResponse();
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Pump Deleted Successfully";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Pump with Id" + PumpId + "Is Not Present";
                }
                return Ok(jsonResponse);
            }
            catch
            {
                return BadRequest("Deletion Failed");
            }
        }
    }
}
