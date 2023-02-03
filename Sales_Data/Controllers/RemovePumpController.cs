using Microsoft.AspNetCore.Mvc;
using Sales_Data.DataContext;
using Sales_Data.Models;
using Pump_Data.Models;
using Sales_Data.Services;
using NLog;
using ILogger = NLog.ILogger;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Authorization;

namespace Sales_Data.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/[controller]")]
    public class RemovePumpController : Controller
    {
        RemovePumpRecordService removePumpRecordService;

        private static readonly ILogger logger = LogManager.GetCurrentClassLogger();

        public RemovePumpController(SalesDBContext salesDBContext) 
        {
            removePumpRecordService = new RemovePumpRecordService(salesDBContext);
        }
        [HttpPost]
        public IActionResult GetPumpDetails(PumpData pumpDetails)
        {
            Console.WriteLine(pumpDetails.tblPumpID);
            Console.WriteLine(pumpDetails.tblFinalLitres);
            try
            {
                return Ok(removePumpRecordService.GetPumpDetails(pumpDetails.tblPumpID, pumpDetails.tblFinalLitres));
            }catch(Exception ex)
            {
                logger.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }

        [HttpPost]
        [Route("deletepump")]
        public IActionResult DeletPumpDetails(JsonData jsonData)
        {
            Console.WriteLine(jsonData);
            
            try
            {
                JsonResponse jsonResponse = new JsonResponse();
                bool status = removePumpRecordService.DeletPumpDetails(jsonData);
                if(status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Record Deleted";
                }else
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Record Not Deleted";
                }
                return Ok(jsonResponse);
            }
            catch(Exception ex) 
            {
                logger.Error(ex.ToString());
                return BadRequest(ex.ToString());
            }
        }
    }
}
