using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface ICastRepository : IAsyncRepository<Cast>
    {
        Task<List<Cast>> GetCastsByMovieId(int id);
    }
}
