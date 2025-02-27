
using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;
using Ecommerce.Repository.Repositories;

namespace Dashboard.Repository;

public class OrderBaseRepository : BaseRepository<Order>,IOrderBaseRepository
{
    public OrderBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}