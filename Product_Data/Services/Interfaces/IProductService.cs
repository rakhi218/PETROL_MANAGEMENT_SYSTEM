using Product_Data.Models;

namespace Product_Data.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();
    }
}
