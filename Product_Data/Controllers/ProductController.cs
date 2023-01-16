using Microsoft.AspNetCore.Mvc;
using Product_Data.DataContext;
using Product_Data.Services;

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
        {
            return Ok(productService.GetProducts());
        }
    }
}
