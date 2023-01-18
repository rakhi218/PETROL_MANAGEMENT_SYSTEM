using Microsoft.AspNetCore.Mvc;
using Sales_Data.DataContext;
using Sales_Data.Models;
using Sales_Data.Services;
using Pump_Data.Models;
using System.Text.Json;

namespace Sales_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PumpSalesController : Controller
    {
        PumpSalesService pumpSalesService; 
        public PumpSalesController(SalesDBContext salesDBContext) 
        {
            pumpSalesService = new PumpSalesService(salesDBContext);
        }

        [HttpPost]
        [Route("CreatePumpRecordEntry")]
        public IActionResult CreatePumpRecordEntry(PumpRecord pumpRecord)
        {
            try
            {
                JsonResponse jsonResponse = new JsonResponse();
                bool status = pumpSalesService.CreatePumpRecordEntry(pumpRecord);
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Updated Pump Type and Pump Record Table";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Failed to update tables";
                }
                return Ok(jsonResponse);
            }
            catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("CreateSalesEntry")]
        public IActionResult CreateSalesEntry(SalesRecord salesRecord)
        {
            try
            {
                JsonResponse jsonResponse = new JsonResponse();
                bool status = pumpSalesService.CreateSalesEntry(salesRecord);
                if (status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Updated Sales Record Table";
                }
                else
                {
                    jsonResponse.Result = false;
                    jsonResponse.Message = "Failed to update tables";
                }
                return Ok(jsonResponse);
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
