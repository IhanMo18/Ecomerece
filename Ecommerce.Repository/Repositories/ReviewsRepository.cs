using Ecommerce.Data.Data;
using Ecommerce.Domain.Interface.Repository;
using Ecommerce.Domain.Models;

namespace Ecommerce.Repository.Repositories;

public class ReviewsRepository : BaseRepository<Reviews>,IReviewsRepository
{
    public ReviewsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public Products SearchReviewByProducts(int productId)
    {
        throw new NotImplementedException();
    }
}