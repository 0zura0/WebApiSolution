using Domain.Models;
using Microsoft.AspNetCore.Mvc;
using Services.Abstraction;
using Services.Implemetation;

namespace WebapiApp.Controllers
{
    [Route("api/[Controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService prodictService)
        {
            _productService = prodictService;
        }

        // Get All Products
        [HttpGet("/products")]
        public async Task<List<Product>> GetAllProducts()
        {
            return await _productService.GetAllProduct();
        }

        // Get a product by ID
        [HttpGet("/products/{id}")]
        public async Task<Product> GetProductById(int id)
        {
            return await _productService.GetProductbyID(id);
        }

        // Add new Product

        [HttpPost("/products")]
        public async Task<Product> AddProduct([FromBody] Product product)
        {
            return await _productService.AddOneProduct(product);
        }


        // Update Product by ID

        [HttpPut("/products/{id}")]
        public Product UpdateProduct(int id, [FromBody] Product product)
        {
            return _productService.UpdateOneProduct(id, product);
        }

        // Delete product by ID

        [HttpDelete("/products/{id}")]
        public Product DeleteProductById(int id)
        {
            return _productService.DeleteProduct(id);
        }





        // Get all product from one category by CategoryID
        [HttpGet("/products/category/{id}")]
        public async Task<List<Product>> GetProductsByCategoryId(int id)
        {
            return await _productService.RetriveProductsByCategory(id);
        }


        //Retrieving the total price of products per category

        [HttpGet("/products/All/prices")]
        public async Task<List<Decimal>> GetTotalPriceOfProductsForEachCategory()
        {
            return await _productService.RetriveTotalPriceOfProductPerCategory();
        }

        // Get total price of products with CategoryID

        [HttpGet("/products/All/category/{id}")]
        public async Task<Decimal> GetTotalPriceOfProductsWithCategory(int id)
        {
            return await _productService.RetriveTotalPriceByCategory(id);
        }


    }
}
