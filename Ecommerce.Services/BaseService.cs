using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;

namespace Ecommerce.Services;

public class BaseService<T>(IRepository<T> repository) : IBaseService<T>
    where T : class
{

    public async Task<IEnumerable<T?>> GetAllAsync()
    {
        return await repository.GetAllAsync();
    }

    public async Task<T?> GetByIdAsync(int id)
    {
        return await repository.GetAsync(id);
    }

    public void Save()
    {
        repository.Save();
    }

    public void Update(T? obj)
    {
        repository.Update(obj);
    }
}