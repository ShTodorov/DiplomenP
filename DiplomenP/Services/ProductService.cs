using DiplomenP.Data;
using DiplomenP.Interfaces;
using DiplomenP.Models;
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

    }
}
