using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Repository;

public interface IProductRepository : IRepository<Products>
{
    public Products? GetProductsWhitCategory(int id);
}