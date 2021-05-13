using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class MovieService : IMovieService
    {
        private readonly IMovieRepository _movieRepository;
        private readonly ICastRepository _castRepository;
        private readonly IGenreRepository _genreRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;

        public MovieService(IMovieRepository movieRepository, ICastRepository castRepository
            ,IGenreRepository genreRepository, IPurchaseRepository purchaseRepository, IMapper mapper)
        {
            _movieRepository = movieRepository;
            _castRepository = castRepository;
            _genreRepository = genreRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
        }

        public async Task<MovieDetailsResponseModel> GetMovieDetails(int id)
        {
            var result = new MovieDetailsResponseModel();
            //result.Genres = await _genreRepository.GetGenresByMovieId(id);
            var movie = await _movieRepository.GetByIdAsync(id);
            result.Movie = new MovieModel() { 
                Id = movie.Id,
                BackdropUrl = movie.BackdropUrl,
                Budget = movie.Budget,
                CReatedBy = movie.CReatedBy,
                CreatedDate = movie.CreatedDate,
                ImdbUrl = movie.ImdbUrl,
                OriginalLanguage = movie.OriginalLanguage,
                Overview = movie.Overview,
                PosterUrl = movie.PosterUrl,
                Price = movie.Price,
                Rating = movie.Rating,
                ReleaseDate = movie.ReleaseDate,
                Revenue = movie.Revenue,
                RunTime = movie.RunTime,
                Tagline = movie.Tagline,
                Title = movie.Title,
                TmdbUrl = movie.TmdbUrl,
                UpdatedBy = movie.UpdatedBy,
                UpdatedDate = movie.UpdatedDate
            };
            result.Genres = new List<GenreModel>();
            foreach(var item in movie.Genres)
            {
                result.Genres.Add(new GenreModel() { 
                    Id = item.Id,
                    Name = item.Name
                });
            }
            var casts = await _castRepository.GetCastsByMovieId(id);
            var moviecast = new List<CastModel>();
            foreach(var cast in casts)
            {
                var chara = movie.MovieCasts.Where(m => m.CastId == cast.Id && m.MovieId == id).Select(m => m.Character).FirstOrDefault(); 
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

        public async Task<MovieDetailsResponseModel> GetTopRateMovie()
        {
            var movieId = await _movieRepository.GetTopRatingMovieId();
            var result = await GetMovieDetails(movieId);

            return result;
        }

        public async Task<List<MovieReviewResponseModel>> GetReviewsForMovie(int id)
        {
            var reviews = await _movieRepository.GetReviewsByMovieId(id);
            if (reviews == null)
                throw new NotFoundException("Not found any reviews.");
            var result = new List<MovieReviewResponseModel>();
            foreach(var item in reviews)
            {
                result.Add(new MovieReviewResponseModel() { 
                    MovieId = item.MovieId,
                    Rating = item.Rating,
                    ReviewText = item.ReviewText,
                    UserId = item.UserId
                });
            }

            return result;
        }

        public async Task<Movie> CreateMovie(CreateMovieRequest movieRequest)
        {
            var movie = ConvertRequestToMovie(movieRequest);
            var created = await _movieRepository.AddAsync(movie);

            foreach (var item in movieRequest.Genres)
            {
                await _genreRepository.AddMovieGenre(item.Id,created.Id);
            }

            return created;
        }

        public async Task<Movie> UpdateMovie(CreateMovieRequest movieRequest)
        {
            var movie = ConvertRequestToMovie(movieRequest);
            movie.Id = movieRequest.Id;
            var updated = await _movieRepository.UpdateAsync(movie);

            await _genreRepository.DeleteOldGenre(movie.Id);
            foreach (var item in movieRequest.Genres)
            {
                await _genreRepository.AddMovieGenre(item.Id, movie.Id);
            }

            return updated;
        }

        private Movie ConvertRequestToMovie (CreateMovieRequest request)
        {
            return new Movie() { 
                BackdropUrl = request.BackdropUrl,
                Budget = request.Budget,
                ImdbUrl = request.ImdbUrl,
                OriginalLanguage = request.OriginalLanguage,
                Overview = request.Overview,
                PosterUrl = request.PosterUrl,
                Price = request.Price,
                ReleaseDate = request.ReleaseDate,
                Revenue = request.Revenue,
                RunTime = request.RunTime,
                Tagline = request.Tagline,
                Title = request.Title,
                TmdbUrl = request.TmdbUrl
            };
        }

        public async Task<List<MovieResponseModel>> GetAllMoviePurchases ()
        {
            var purchases = await _purchaseRepository.GetAllPurchases();
            var movies = _mapper.Map<List<MovieResponseModel>>(purchases);

            return movies;
        }
    }
}
