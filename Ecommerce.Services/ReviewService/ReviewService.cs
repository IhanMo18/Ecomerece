using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.ReviewService;

public class ReviewService(IReviewsBaseRepository baseRepository,
    IProductService productService) :BaseService<Reviews>(baseRepository),IReviewService
{
    public Product? SearchReviewByProducts(int productId)
    {
      return productService.GetProductsWithAllReviews(productId);
    }
}