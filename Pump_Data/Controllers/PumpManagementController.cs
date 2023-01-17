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
            return Ok(pumpManagementService.GetAllPumps());
        }

        [HttpPost]
        public IActionResult CreatePump(PumpManagement Pump)
        {
            return Ok(pumpManagementService.CreatePump(Pump));
        }

        [HttpPut]
        public IActionResult UpdatePump(short PumpId,PumpManagement NewPump)
        {
            return Ok(pumpManagementService.UpdatePump(PumpId,NewPump));
        }

        [HttpDelete]
        public IActionResult DeletePump(short PumpId)
        {
            return Ok(pumpManagementService.DeletePump(PumpId));
        }
    }
}
