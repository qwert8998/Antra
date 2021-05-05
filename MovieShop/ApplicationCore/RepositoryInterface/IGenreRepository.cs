using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IGenreRepository : IAsyncRepository<Genre>
    {
        Task<List<Genre>> GetGenresByMovieId(int id);
    }
}
