using Product_Data.DataContext;
using Product_Data.Models;
using Product_Data.Repositories;
using Product_Data.Services.Interfaces;

namespace Product_Data.Services
{
    public class ProductService : IProductService
    {
        ProductRepository productRepository;

        public ProductService(ProductDBContext productDBContext) 
        {
            productRepository = new ProductRepository(productDBContext);
        }

        public IEnumerable<Product> GetProducts()
        {
            return productRepository.GetProducts();
        }
    }
}
