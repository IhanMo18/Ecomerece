using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;
using Microsoft.EntityFrameworkCore;

namespace Dashboard.Repository;

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