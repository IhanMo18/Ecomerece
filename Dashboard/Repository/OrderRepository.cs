using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;

namespace Dashboard.Repository;

public class OrderRepository : BaseRepository<Order>,IOrderRepository
{
    public OrderRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}