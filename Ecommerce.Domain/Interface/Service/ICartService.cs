using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Service;

public interface ICartService :IBaseService<Cart>
{
    public Task<Cart?> SearchCartBySessionid(string sessionId);
  
}