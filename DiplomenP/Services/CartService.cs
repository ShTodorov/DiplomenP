using DiplomenP.Data;
using DiplomenP.Interfaces;
using DiplomenP.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomenP.Services
{
    public class CartService : ICartService
    {
        private readonly ApplicationDbContext _dbContext;

        public CartService(ApplicationDbContext dbContext)
        {
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

    }
}
