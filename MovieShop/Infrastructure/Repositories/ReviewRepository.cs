using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ReviewRepository : EfRepository<Review>, IReviewRepository
    {
        public ReviewRepository(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Review>> GetAllReviewsByUserId (int id)
        {
            var result = await _dbContext.Reviews.Include(r => r.Movie).Where(r => r.UserId == id).ToListAsync();
            return result;
        }
    }
}
