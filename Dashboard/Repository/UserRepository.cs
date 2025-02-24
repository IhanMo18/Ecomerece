using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;

namespace Dashboard.Repository;

public class UserRepository : BaseRepository<User>,IUserRepository
{
    public UserRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}