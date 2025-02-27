namespace Ecommerce.Domain.Interface.Repository;

public interface IBaseRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T?> GetAsync(int id);
    void Update(T obj);
    void Save();
    public void Remove(T obj);
}