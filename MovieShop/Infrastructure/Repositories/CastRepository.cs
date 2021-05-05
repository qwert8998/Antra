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
    public class CastRepository : EfRepository<Cast>, ICastRepository
    {
        public CastRepository(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Cast>> GetCastsByMovieId(int id)
        {
            var result = await _dbContext.MovieCasts.Include(mc => mc.Cast).Where(mc => mc.MovieId == id).Select(c => c.Cast).ToListAsync();
            return result;
        }
    }
}
