using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FavoriteReposiotry : EfRepository<Favorite>, IFavoriteRepository
    {
        public FavoriteReposiotry(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Favorite>> GetAllFavoriteByUserId (int id)
        {
            var result = 
                await _dbContext.Favorites.Include(f => f.Movie).Where(f => f.UserId == id).ToListAsync();
            return result;
        }
    }
}
