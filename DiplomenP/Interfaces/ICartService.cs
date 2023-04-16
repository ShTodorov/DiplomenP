namespace DiplomenP.Interfaces
{
    public interface ICartService
    {
        Task AddToCart(int productId, int quantity, string customerId);

    }
}
