using ApplicationCore.Models.Response;
using System.Collections.Generic;

namespace ApplicationCore.ServiceInterface
{
    public interface IMovieService
    {
        List<MovieResponseModel> GetTop30RevenueMovies();
    }
}
