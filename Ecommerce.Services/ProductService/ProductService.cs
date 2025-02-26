using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.ProductService;

public class ProductService(IProductRepository repository) : BaseService<Products>(repository), IProductService
{

    public Products? GetProductsWithCategory(int productId)
    {
        return repository.GetProductsWithCategory(productId);
    }

    public Products? GetProductsWithAllReviews(int productId)
    {
        return repository.GetProductsWithAllReviews(productId);
    }
}