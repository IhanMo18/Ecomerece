using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce.Repository.Repositories;

public class ProductRepository : BaseRepository<Products>,IProductRepository
{
    public ProductRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
    
    
    public Products? GetProductsWhitCategory(int id)
    {
        Products? productWithCategory = _dbContext.Products
            .Include(obj => obj.Category)
            .FirstOrDefault(product => product.Id == id); // Asegúrate de que 'Category' es la propiedad correct
        return productWithCategory;
    }
    
}