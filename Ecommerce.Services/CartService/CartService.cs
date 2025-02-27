
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Repositories;

namespace Ecommerce.Services.CartService;

public class CartService(ICartBaseRepository baseRepository) : BaseService<Cart>(baseRepository), ICartService
{
    public async Task<Cart?> SearchCartBySessionid(string sessionId)
    {
       return await baseRepository.SearchCartBySessionid(sessionId);
    }

    public void AddProductToCart(string sessionId, int productId, int quantity)
    {
        baseRepository.AddProductToCart(sessionId,productId,quantity);
    }
    
    public void RemoveProductFromCart(ProductCart productCart)
    {
        baseRepository.RemoveProductFromCart(productCart);
    }
    
    
}