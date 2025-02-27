using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.ProductService;

public class ProductService(IProductBaseRepository baseRepository) : BaseService<Product>(baseRepository), IProductService
{

    public Product? GetProductsWithCategory(int productId)
    {
        return baseRepository.GetProductsWithCategory(productId);
    }

    public Product? GetProductsWithAllReviews(int productId)
    {
        return baseRepository.GetProductsWithAllReviews(productId);
    }
}