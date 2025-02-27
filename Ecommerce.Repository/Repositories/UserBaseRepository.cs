using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class UserBaseRepository : BaseRepository<User>,IUserBaseRepository
{
    public UserBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}