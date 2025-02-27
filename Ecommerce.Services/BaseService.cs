using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;

namespace Ecommerce.Services;

public class BaseService<T>(IBaseRepository<T> baseRepository) : IBaseService<T>
    where T : class
{

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await baseRepository.GetAllAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await baseRepository.GetAsync(id);
    }

    public void Save()
    {
        baseRepository.Save();
    }

    public void Update(T? obj)
    {
        baseRepository.Update(obj);
    }

    public void Remove(T obj)
    {
        baseRepository.Remove(obj);
    }
}