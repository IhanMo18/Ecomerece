using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;

namespace Dashboard.Repository;

public class OrderDetailRepository :BaseRepository<OrderDetail>,IOrderDetailRepository
{
    public OrderDetailRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}