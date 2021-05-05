using ApplicationCore.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterface
{
    public interface IGenreService
    {
        Task<IEnumerable<GenreResponseModel>> GetAllGenres();
    }
}
