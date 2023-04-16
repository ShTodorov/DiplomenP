using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(string productName, double price, string type, int productCount, string image, string description, string brand);

        List<Product> GetProducts();

        Task<bool> UpdateProductByName(string name, double? newPrice, int? newCount);

        Task<bool> ProductExists(string productName);

        Task DeleteProductAsync(int productId);
    }
}
