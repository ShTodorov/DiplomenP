using DiplomenP.Data;
using DiplomenP.Interfaces;
using DiplomenP.Models;
using Microsoft.EntityFrameworkCore;

namespace DiplomenP.Services
{
    public class OrderService : IOrderService
    {

        private readonly ApplicationDbContext _dbContext;

        public OrderService(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }


        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _dbContext.Orders.ToListAsync();
        }


        public async Task<Order> CreateOrderAsync(Order newOrder)
        {
            _dbContext.Orders.Add(newOrder);
            await _dbContext.SaveChangesAsync();
            return newOrder;
        }

    }
}