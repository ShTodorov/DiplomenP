using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(int productId, int quantity, string customerId);
        Task ClearCartAsync(string userId);
        Task<List<CartItem>> GetCartItemsAsync(string userId);
        Task RemoveCartItemAsync(int cartItemId);
    }
}
