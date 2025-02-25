using Microsoft.EntityFrameworkCore;
using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class CartRepository(ApplicationDbContext dbContext) : BaseRepository<Cart>(dbContext),ICartRepository
{
    
    public async Task<Cart?> SearchCartBySessionid(string? sessionId)
    {
       return await _dbContext.Cart.
           Include(c=>c.Products)
           .FirstOrDefaultAsync(c => c.SessionId == sessionId);
    }
}