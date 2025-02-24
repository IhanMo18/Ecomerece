using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository;

public class CartRepository : BaseRepository<Cart>,ICartRepository
{
    public CartRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    

    public Cart? SearchCartBySessionid(string sessionId)
    {
       return _dbContext.Cart.Include(c=>c.Products)
           .FirstOrDefault(c => c.SessionId == sessionId);
    }
}