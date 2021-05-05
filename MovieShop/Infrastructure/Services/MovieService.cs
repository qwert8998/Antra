using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly ICastRepository _castRepository;
        private readonly IMovieCastRepository _movieCastRepository;

        public MovieService(IMovieRepository movieRepository, IGenreRepository genreRepository
            , ICastRepository castRepository, IMovieCastRepository movieCastRepository)
        {
            _movieRepository = movieRepository;
            _genreRepository = genreRepository;
            _castRepository = castRepository;
            _movieCastRepository = movieCastRepository;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var result = new MovieDetailsResponseModel();
            result.Genres = await _genreRepository.GetGenresByMovieId(id);
            result.Movie = await _movieRepository.GetByIdAsync(id);
            var casts = await _castRepository.GetCastsByMovieId(id);
            var moviecast = new List<CastModel>();
            foreach(var cast in casts)
            {
                var chara = await _movieCastRepository.GetMovieCastByMovieIdAndCastId(id, cast.Id);
                moviecast.Add(new CastModel { 
                    Id = cast.Id,
                    Name = cast.Name,
                    ProfilePath = cast.ProfilePath,
                    Character = chara.Character
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
