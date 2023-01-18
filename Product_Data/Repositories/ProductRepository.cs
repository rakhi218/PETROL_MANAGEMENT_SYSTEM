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
            try
            {
                return productDBContext.Products_Data.ToList();
            }
            catch
            {
                //left for logging
                return null;
            }
        }

        public Boolean UpdatesProduct(string ProductType,Product NewProduct)
        {
            try
            {
                var product = productDBContext.Products_Data.Find(ProductType);
                if (product != null)
                {
                    product.tblCost = NewProduct.tblCost;
                    productDBContext.SaveChanges();
                    return true;
                }
                return false;
            }
            catch
            {
                //left for logging
                throw null;
            }
        }
    }
}
