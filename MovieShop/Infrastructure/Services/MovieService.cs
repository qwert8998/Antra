using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICastRepository _castRepository;

        public MovieService(IMovieRepository movieRepository, ICastRepository castRepository)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var result = new MovieDetailsResponseModel();
            //result.Genres = await _genreRepository.GetGenresByMovieId(id);
            result.Movie = await _movieRepository.GetByIdAsync(id);
            result.Genres = result.Movie.Genres.ToList();
            var casts = await _castRepository.GetCastsByMovieId(id);
            var moviecast = new List<CastModel>();
            foreach(var cast in casts)
            {
                var chara = result.Movie.MovieCasts.Where(m => m.CastId == cast.Id && m.MovieId == id).Select(m => m.Character).FirstOrDefault(); 
                moviecast.Add(new CastModel { 
                    Id = cast.Id,
                    Name = cast.Name,
                    ProfilePath = cast.ProfilePath,
                    Character = chara
                });
            }
            result.Casts = moviecast;
            return result;
        }

        public async Task<List<MovieCardResponseModel>> GetMoviesByGenre(int id)
        {
            var movies = await _movieRepository.GetMoviesByGenre(id);

            var results = new List<MovieCardResponseModel>();
            foreach(var item in movies)
            {
                results.Add(new MovieCardResponseModel { 
                    Id = item.Id,
                    Title = item.Title,
                    Budget = item.Budget.Value,
                    PostUrl = item.PosterUrl
                });
            }
            return results;
        }

        public async Task<List<MovieCardResponseModel>> GetTop30RevenueMovies()
        {
            var movies = await _movieRepository.GetTop30RevenueMovies();

            var topMovies = new List<MovieCardResponseModel>();
            foreach (var movie in movies)
            {
                topMovies.Add(new MovieCardResponseModel
                {
                    Id = movie.Id,
                    Budget = movie.Budget.Value,
                    Title = movie.Title,
                    PostUrl = movie.PosterUrl
                });
            }

            return topMovies;
        }
    }
}
