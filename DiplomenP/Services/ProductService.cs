using DiplomenP.Data;
using DiplomenP.Interfaces;
using DiplomenP.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomenP.Services
{
    public class ProductService : IProductService
    {
        private readonly ApplicationDbContext _dbContext;

        public ProductService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task CreateProductAsync(string productName, double price, string type, int productCount, string image, string description, string brand)
        {

                var newProduct = new Product
                {
                    ProductName = productName,
                    Price = price,
                    Type = type,
                    ProductCount = productCount,
                    Image = image,
                    Description = description,
                    Brand = brand
                };

                _dbContext.Products.Add(newProduct);
                await _dbContext.SaveChangesAsync();
        }

        public List<Product> GetProducts()
        {

            return _dbContext.Products.ToList();

        }

        public async Task<bool> UpdateProductByName(string name, double? newPrice, int? newCount)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductName == name);

            if (product == null)
            {
                return false;
            }

            if (newPrice.HasValue)
            {
                product.Price = newPrice.Value;
            }

            if (newCount.HasValue)
            {
                product.ProductCount = newCount.Value;
            }

            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> ProductExists(string productName)
        {
            var product = await _dbContext.Products.FirstOrDefaultAsync(p => p.ProductName == productName);
            return product != null;
        }

        public async Task DeleteProductAsync(int productId)
        {
            var product = await _dbContext.Products.FindAsync(productId);

            if (product != null)
            {
                _dbContext.Products.Remove(product);
                await _dbContext.SaveChangesAsync();
            }
        }


    }
}
