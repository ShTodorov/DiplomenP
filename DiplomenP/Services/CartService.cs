using DiplomenP.Data;
using DiplomenP.Interfaces;
using DiplomenP.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomenP.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CartService(IHttpContextAccessor httpContextAccessor, ApplicationDbContext dbContext)
        {
            _httpContextAccessor = httpContextAccessor;
            _dbContext = dbContext;
        }


        public async Task AddToCart(int productId, int quantity, string customerId)
        {
            // Retrieve the cart for the specified customer from the database using EF Core
            var cart = await _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CartCustomerId == customerId);

            if (cart == null)
            {
                // If the customer doesn't have a cart yet, create a new one
                cart = new Cart
                {
                    CartCustomerId = customerId,
                    Items = new List<CartItem>()
                };
                _dbContext.Carts.Add(cart);
                await _dbContext.SaveChangesAsync();
            }

            // Check if the selected product is already in the cart
            var cartItem = cart.Items.FirstOrDefault(i => i.CartItemProductId == productId);

            if (cartItem == null)
            {
                // If the product isn't already in the cart, create a new cart item for it
                cartItem = new CartItem
                {
                    Quantity = quantity,
                    CartItemProductId = productId,
                    CartId = cart.CartId
                };
                cart.Items.Add(cartItem);
                _dbContext.CartItems.Add(cartItem);
            }
            else
            {
                // If the product is already in the cart, update its quantity
                cartItem.Quantity += quantity;
            }

            // Save changes to the database
            await _dbContext.SaveChangesAsync();
        }


        public async Task<List<CartItem>> GetCartItemsAsync(string userId)
        {
            return await _dbContext.CartItems
                .Include(ci => ci.CartItemProduct)
                .Where(ci => ci.Cart.CartCustomerId == userId)
                .ToListAsync();
        }


        public async Task RemoveCartItemAsync(int cartItemId)
        {
            var cartItem = await _dbContext.CartItems.FirstOrDefaultAsync(x => x.CartItemId == cartItemId);
            _dbContext.CartItems.Remove(cartItem);
            await _dbContext.SaveChangesAsync();
        }


        public async Task ClearCartAsync(string userId)
        {
            var cart = await _dbContext.Carts
                .Include(c => c.Items)
                .FirstOrDefaultAsync(c => c.CartCustomerId == userId);
            _dbContext.CartItems.RemoveRange(cart.Items);
            await _dbContext.SaveChangesAsync();
        }


        public async Task<int> GetCartId(string userId)
        {
            var cart = await _dbContext.Carts.FirstOrDefaultAsync(c => c.CartCustomerId == userId);
            return cart.CartId;
        }


        public async Task<double> GetCartTotalPriceAsync(int cartId)
        {
            var cartItems = await _dbContext.CartItems
                .Where(ci => ci.CartId == cartId)
                .Include(ci => ci.CartItemProduct)
                .ToListAsync();

            return cartItems.Sum(ci => ci.Quantity * ci.CartItemProduct.Price);
        }

    }

}
