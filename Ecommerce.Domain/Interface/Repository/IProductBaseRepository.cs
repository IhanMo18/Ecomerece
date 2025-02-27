using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Repository;

public interface IProductBaseRepository : IBaseRepository<Product>
{
    public Product? GetProductsWithCategory(int id);
    public Product? GetProductsWithAllReviews(int id);
}