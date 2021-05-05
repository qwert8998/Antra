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
            var movie = await _dbContext.Movies.Include(m => m.Genres).FirstOrDefaultAsync(m => m.Id == id);
            // cast for that movie
            // Average Rating
            // Genres for that movie
            // Show Buy Button when user is not Login in the website and show when user is login and not purchased
            // Show Watch Movie button when user is login and already bought the movie
            // Include
            // ThenInclude
            var rating = await _dbContext.Reviews.Where(r => r.MovieId == id).AverageAsync(r => r.Rating);
            movie.Rating = rating;
            return movie;

        }

        public async Task<IEnumerable<Movie>> GetMoviesByGenre(int Id)
        {
            var movies =
                await _dbContext.Genres.Include(g => g.Movies).Where(g => g.Id == Id).SelectMany(g => g.Movies).ToListAsync();
            return movies;
        }
        //First() : First() will throw an exception if there is no result data
        //FirstOrDefault() : FirstOrDefault() returns a default value (null) if there is no result data
        //Single() : Returns the only element from a collection, or the only element that satisfies a
        //           condition. If Single() found no elements or more than one elements in the collection
        //           then throws InvalidOperationException.
        //SingleOrDefault() : The same as Single, except that it returns a default value of a specified
        //                    generic type, instead of throwing an exception if no element found for the
        //                    specified condition. However, it will thrown InvalidOperationException
        //                    if it found more than one element for the specified condition in the
        //                    collection.
        //Where()
        //GroupBy()
        //ToList()
        //Any()
    }
}
