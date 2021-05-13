using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class GenreRepository : EfRepository<Genre>, IGenreRepository
    {
        public GenreRepository(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Genre>> GetGenresByMovieId(int id)
        {
            var genres = await _dbContext.Movies.Include(m => m.Genres).Where(m => m.Id == id).SelectMany(g => g.Genres).ToListAsync();
            return genres;
        }

        public async Task AddMovieGenre(MovieGenre movieGenre)
        {
            _dbContext.Set<MovieGenre>().Add(movieGenre);
            await _dbContext.SaveChangesAsync();

        }
    }
}
