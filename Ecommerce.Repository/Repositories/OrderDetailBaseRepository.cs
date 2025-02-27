using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class OrderDetailBaseRepository :BaseRepository<OrderDetail>,IOrderDetailBaseRepository
{
    public OrderDetailBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}