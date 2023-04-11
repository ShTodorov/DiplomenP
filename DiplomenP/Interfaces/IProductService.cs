using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface IProductService
    {
        Task CreateProductAsync(string productName, double price, string type, int productCount, string image, string description, string brand);

        List<Product> GetProducts();

    }
}
