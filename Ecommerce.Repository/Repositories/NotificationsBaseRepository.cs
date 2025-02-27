
using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class NotificationsBaseRepository : BaseRepository<Notifications>, INotificationsBaseRepository
{
    
    public NotificationsBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}