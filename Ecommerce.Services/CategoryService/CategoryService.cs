using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Interface.Service;
using Ecommerce.Domain.Models;

namespace Ecommerce.Services.CategoryService;

public class CategoryService(ICategoryRepository repository) : BaseService<Category>(repository),ICategoryService
{
    
}