using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository;
using Microsoft.EntityFrameworkCore;


public class CategoryRepository : BaseRepository<Category>, ICategoryRepository
{
    public CategoryRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
}