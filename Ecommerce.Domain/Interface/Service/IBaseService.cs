namespace Ecommerce.Domain.Interface.Service;

public interface IBaseService<T> where T : class
{
    public Task<IEnumerable<T?>> GetAllAsync();
    
    public Task<T?> GetByIdAsync(int id);
    public void Save();
    public void Update(T? obj);
}