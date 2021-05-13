using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterface
{
    public interface IMovieService
    {
        Task<List<MovieCardResponseModel>> GetTop30RevenueMovies();
        Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id);
        Task<MovieDetailsResponseModel> GetMovieDetails(int id);
        Task<MovieDetailsResponseModel> GetTopRateMovie();
        Task<List<MovieReviewResponseModel>> GetReviewsForMovie(int id);
        Task<Movie> CreateMovie(CreateMovieRequest movieRequest);
    }
}
