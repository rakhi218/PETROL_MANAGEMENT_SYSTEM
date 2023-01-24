using Microsoft.AspNetCore.Mvc;
using Product_Data.DataContext;
using Product_Data.Models;
using Product_Data.Services;
using Pump_Data.Models;

namespace Product_Data.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductController : Controller
    {
        ProductService productService;

        public ProductController(ProductDBContext productDBContext) 
        {
            productService = new ProductService(productDBContext);
        }

        [HttpGet]
        public IActionResult GetProducts()
        {   try
            {
                return Ok(productService.GetProducts());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult UpdateProduct(Double cost1, Double cost2, Double cost3, Double cost4)
        {
            try
            {
                Console.WriteLine("hello");
                bool status = productService.UpdatesProduct(cost1, cost2, cost3, cost4);
                JsonResponse jsonResponse = new JsonResponse();
                if(status)
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Update Successful";
                }
                else
                {
                    jsonResponse.Result = true;
                    jsonResponse.Message = "Update Failed";
                }
                return Ok(jsonResponse);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
