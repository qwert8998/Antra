using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieRepository : EfRepository<Movie>, IMovieRepository
    {
        public MovieRepository(MovieShopDBContext dbcontext): base(dbcontext)
        {

        }
        public async Task<IEnumerable<Movie>> GetTop30RevenueMovies()
        {
            var movies = await _dbContext.Movies.OrderByDescending(m => m.Revenue).Take(30).ToListAsync();
            return movies;
        }

        public override async Task<Movie> GetByIdAsync(int id)
        {
            var movie = await _dbContext.Movies.FirstOrDefaultAsync(m => m.Id == id);
            return movie;

        }
        //First()
        //FirstOrDefault()
        //Single()
        //SingleOrDefault()
        //Where()
        //GroupBy()
        //ToList()
        //Any()
    }
}
