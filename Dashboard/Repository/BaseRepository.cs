
using System.Globalization;
using Dashboard.Data;
using Dashboard.Models;
using Microsoft.EntityFrameworkCore;
namespace Dashboard.Repository;

public class BaseRepository<T> : IRepository<T> where T:class
{
    protected ApplicationDbContext _dbContext;
    private DbSet<T> _dbSet;

    public BaseRepository(ApplicationDbContext dbContext)
    {
       _dbContext =dbContext;
       _dbSet = _dbContext.Set<T>();
    }
    public IEnumerable<T> GetAll()
    {
        IQueryable<T> queryable = _dbSet;
        return queryable.ToList();
    }

    public T Get(int id)
    {
        return _dbSet.Find(id) ?? throw new CultureNotFoundException();
    }
    

    public void Update(T obj)
    {
        _dbSet.Update(obj);
         _dbContext.SaveChanges();
    }

    public void Save()
    {
        _dbContext.SaveChanges();
    }


    public T? GetInclude(string include = null)
    {
        IQueryable<T> query = _dbSet;
        foreach (var property in include.Split(',',StringSplitOptions.RemoveEmptyEntries))
        {
            query.Include(property);
        }

        return query.FirstOrDefault();
    }
}