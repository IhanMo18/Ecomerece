using Dashboard.Models;

namespace Dashboard.Repository.Interface;

public interface ICartRepository : IRepository<Cart>
{

    public Cart? SearchCartBySessionid(string? sessionId);
}