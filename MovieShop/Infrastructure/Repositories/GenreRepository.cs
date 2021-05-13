using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.Data.SqlClient;
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

        public async Task AddMovieGenre(int genreId, int movieId)
        {
            var sql = @"INSERT dbo.MovieGenre VALUES (@GenreId,@MovieId)";
            SqlParameter[] parameters = new SqlParameter[] 
            { 
                new SqlParameter("@GenreId",genreId),
                new SqlParameter("@MovieId", movieId)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteOldGenre (int movieId)
        {
            var sql = @"DELETE dbo.MovieGenre WHERE MovieId=@MovieId";
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@MovieId", movieId)
            };
            await _dbContext.Database.ExecuteSqlRawAsync(sql, parameters);
            await _dbContext.SaveChangesAsync();
        }
    }
}
