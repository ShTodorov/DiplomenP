using DiplomenP.Models;

namespace DiplomenP.Interfaces
{
    public interface IOrderService
    {
        Task<Order> CreateOrderAsync(Order newOrder);
        Task<List<Order>> GetOrdersAsync();
        Task<List<Order>> GetOrdersForUser(string userId);
    }
}
