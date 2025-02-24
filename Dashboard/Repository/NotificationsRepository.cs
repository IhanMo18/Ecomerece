using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;

namespace Dashboard.Repository;

public class NotificationsRepository : BaseRepository<Notifications>, INotificationsRepository
{
    
    public NotificationsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}