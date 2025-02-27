using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Repository;

public interface ICartBaseRepository : IBaseRepository<Cart>
{

    public Task<Cart?> SearchCartBySessionid(string? sessionId);
    public void AddProductToCart(string sessionId, int productId, int quantity);
    public void RemoveProductFromCart(ProductCart productCart);
}