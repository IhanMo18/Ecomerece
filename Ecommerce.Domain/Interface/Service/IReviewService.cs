using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Service;

public interface IReviewService : IBaseService<Reviews>
{
    public Product? SearchReviewByProducts(int productId);
}