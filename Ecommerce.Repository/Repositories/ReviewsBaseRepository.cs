using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class ReviewsBaseRepository : BaseRepository<Reviews>,IReviewsBaseRepository
{
    public ReviewsBaseRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Product SearchReviewByProducts(int productId)
    {
        throw new NotImplementedException();
    }
}