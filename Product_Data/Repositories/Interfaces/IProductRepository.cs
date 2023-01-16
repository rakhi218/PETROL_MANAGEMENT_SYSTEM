using Product_Data.Models;

namespace Product_Data.Repositories.Interfaces
{
    public interface IProductRepository
    {
        public IEnumerable<Product> GetProducts();
    }
}
