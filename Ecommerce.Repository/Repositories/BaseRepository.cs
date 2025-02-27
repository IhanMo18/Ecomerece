using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Repositories;

public class BaseRepository<T> : IBaseRepository<T> where T : class
{
    protected ApplicationDbContext _dbContext;
    private DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbSet = _dbContext.Set<T>();
    }

    public async Task<IEnumerable<T>> GetAllAsync()
    {
        return await _dbSet.ToListAsync();
    }

    public async Task<T?> GetAsync(int id)
    {
        return await _dbSet.FindAsync(id);
    }

    public void Update(T obj)
    {
        _dbSet.Update(obj);
        _dbContext.SaveChanges();
    }
    public void Remove(T obj)
    {
        _dbContext.Remove(obj);
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }
}