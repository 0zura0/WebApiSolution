
using Domain.Models;

namespace Services.Abstraction
{
    public interface IProductService
    {
        public Task<List<Product>> GetAllProduct();
        public Task<Product> GetProductbyID(int id);
        public Task<Product> AddOneProduct(Product product);
        public Product UpdateOneProduct(int id,Product product);
        public Product DeleteProduct(int id);
        public Task<List<Product>> RetriveProductsByCategory(int categoryID);
        public Task<Decimal> RetriveTotalPriceByCategory(int categoryID);
        public Task<List<Decimal>> RetriveTotalPriceOfProductPerCategory();
    }
}
