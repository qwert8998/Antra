using ApplicationCore.Entities;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IMovieCastRepository : IAsyncRepository<MovieCast>
    {
        Task<MovieCast> GetMovieCastByMovieIdAndCastId(int movieId, int castId);
    }
}
