using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class MovieCastRepository : EfRepository<MovieCast>, IMovieCastRepository
    {
        public MovieCastRepository(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<MovieCast> GetMovieCastByMovieIdAndCastId(int movieId, int castId)
        {
            var result = await _dbContext.MovieCasts.Where(x => x.MovieId == movieId && x.CastId == castId).FirstOrDefaultAsync();
            return result;
        }
    }
}
