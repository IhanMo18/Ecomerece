using Dashboard.Data;
using Dashboard.Models;
using Dashboard.Repository.Interface;

namespace Dashboard.Repository;

public class ReviewsRepository : BaseRepository<Reviews>,IReviewsRepository
{
    public ReviewsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}