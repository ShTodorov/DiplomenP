using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(int productId, int quantity, string customerId);
        Task ClearCartAsync(string userId);
        Task<int> GetCartId(string userId);
        Task<List<CartItem>> GetCartItemsAsync(string userId);
        Task<double> GetCartTotalPriceAsync(int cartId);
        Task RemoveCartItemAsync(int cartItemId);
        Task UpdateCartItemAsync(CartItem cartItem);
    }
}
