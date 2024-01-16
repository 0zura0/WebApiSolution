using Data.DBContext;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Services.Abstraction;


namespace Services.Implemetation
{
    public class ProductService : IProductService
    {
        private readonly AppDbContext _contextDb;
        public ProductService(AppDbContext context)
        {
            _contextDb = context;
        }

        public async Task<Product> AddOneProduct(Product product)
        {
            await this._contextDb.AddAsync(product);
            await this._contextDb.SaveChangesAsync();
            return product;
        }

        public Product DeleteProduct(int id )
        {
            var product = this._contextDb.products.FirstOrDefault(p => p.Id == id);

            if (product != null)
            {
                this._contextDb.products.Remove(product);
                this._contextDb.SaveChanges();
                return product;
            }
            else
            {
                throw new Exception("Product not found");
            };
                
        }

        public async Task<List<Product>> GetAllProduct()
        {
            return await this._contextDb.products.ToListAsync();
        }


        public async Task<Product> GetProductbyID(int id)
        {
            var prod = await this._contextDb.products.FirstOrDefaultAsync(p => p.Id == id);
            if (prod != null)
            {
                return prod;
            }
            else
            {
                throw new Exception("there is not product with such id");
            }
        }

        public async Task<decimal> RetriveTotalPriceByCategory(int categoryID)
        {
            return await this._contextDb.products.Where(p=> p.CategoryId ==categoryID).SumAsync(x=> x.Price);
        }





        public async Task<List<Product>> RetriveProductsByCategory(int categoryID)
        {
            return await this._contextDb.products.Where(x => x.Id == categoryID).ToListAsync();
        }



        public async Task<List<decimal>> RetriveTotalPriceOfProductPerCategory()
        {
            return await this._contextDb.products.GroupBy(x => x.CategoryId).Select(p => p.Sum(n => n.Price)).ToListAsync();
        }



        public Product UpdateOneProduct(int id,Product product)
        {
            var prod = this._contextDb.products.FirstOrDefault(p => p.Id == id);
            if(prod != null)
            {
                prod.Price = product.Price;
                prod.Name = product.Name;
                _contextDb.SaveChanges();
                return prod;
            }
            else
            {
                throw new Exception("prod is not found");
            }
        }
    }
}
