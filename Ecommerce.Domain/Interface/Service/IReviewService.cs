using Ecommerce.Domain.Models;

namespace Ecommerce.Domain.Interface.Service;

public interface IReviewService : IBaseService<Reviews>
{
    public Products? SearchReviewByProducts(int productId);
}