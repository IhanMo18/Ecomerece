using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class CategoryBaseRepository : BaseRepository<Category>, ICategoryBaseRepository
{
    public CategoryBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
}