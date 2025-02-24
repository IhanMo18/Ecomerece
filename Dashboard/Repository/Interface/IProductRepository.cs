using Dashboard.Models;

namespace Dashboard.Repository.Interface;

public interface IProductRepository : IRepository<Products>
{
    public Products? GetProductsWhitCategory(int id);
}