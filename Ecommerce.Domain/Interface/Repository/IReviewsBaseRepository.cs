using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Repository;

public interface IReviewsBaseRepository : IBaseRepository<Reviews>
{
    public Product SearchReviewByProducts(int productId);
}