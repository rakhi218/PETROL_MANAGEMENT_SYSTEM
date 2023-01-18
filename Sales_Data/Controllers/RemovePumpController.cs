﻿using Microsoft.AspNetCore.Mvc;
using Sales_Data.DataContext;
using Sales_Data.Models;
using Pump_Data.Models;
using Sales_Data.Services;

namespace Sales_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RemovePumpController : Controller
    {
        RemovePumpRecordService removePumpRecordService;
        public RemovePumpController(SalesDBContext salesDBContext) 
        {
            removePumpRecordService = new RemovePumpRecordService(salesDBContext);
        }
        [HttpPost]
        public IActionResult GetPumpDetails(int PumpId, double tblFinalLitres)
        {
            try
            {
                return Ok(removePumpRecordService.GetPumpDetails(PumpId,tblFinalLitres));
            }catch(Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete]
        public IActionResult DeletPumpDetails(JsonData jsonData)
        {
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
                return BadRequest(ex.Message);
            }
        }
    }
}
