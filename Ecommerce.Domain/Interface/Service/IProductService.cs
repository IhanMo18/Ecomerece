using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Service;

public interface IProductService : IBaseService<Products>
{
    public Products? GetProductsWithCategory(int id);
    public Products? GetProductsWithAllReviews(int id);
}