using Product_Data.DataContext;
using Product_Data.Models;
using Product_Data.Repositories.Interfaces;

namespace Product_Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ProductDBContext productDBContext;
        public ProductRepository(ProductDBContext productDbContext) 
        {
            this.productDBContext = productDbContext;
        }

        public IEnumerable<Product> GetProducts() 
        {
            return productDBContext.Products_Data.ToList();
        }
    }
}
