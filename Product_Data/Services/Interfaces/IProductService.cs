using Product_Data.Models;

namespace Product_Data.Services.Interfaces
{
    public interface IProductService
    {
        public IEnumerable<Product> GetProducts();

        public Boolean UpdatesProduct(string ProductType, Product NewProduct);
    }
}
