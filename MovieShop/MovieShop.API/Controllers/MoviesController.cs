using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }

            return NotFound("Not found any movies.");
        }

        [HttpGet]
        [Route("{id:int}", Name = "GetMoive")]
        public async Task<IActionResult> GetMovieById(int id)
        {
            var movieDetails = await _movieService.GetMovieDetails(id);
            if (movieDetails != null)
            {
                return Ok(movieDetails);
            }

            return NotFound("Not found any movie details.");
        }

        [HttpGet]
        [Route("toprated")]
        public async Task<IActionResult> GetTopRating()
        {
            var movie = await _movieService.GetTopRateMovie();

            if (movie != null)
            {
                return Ok(movie);
            }

            return UnprocessableEntity();
        }

        [HttpGet]
        [Route("toprevenue")]
        public async Task<IActionResult> GetTopMovies()
        {
            var movies = await _movieService.GetTop30RevenueMovies();

            if (movies.Any())
            {
                return Ok(movies);
            }

            return NotFound("Not found any movies.");
        }

        [HttpGet]
        [Route("genre/{genreId:int}")]
        public async Task<IActionResult> GetMoviesByGenre(int genreId)
        {
            var movies = await _movieService.GetMoviesByGenre(genreId);
            return Ok(movies);
        }

        [HttpGet]
        [Route("{id}/reviews")]
        public async Task<IActionResult> GetMovieReviews(int id)
        {
            var reviews = await _movieService.GetReviewsForMovie(id);
            return Ok(reviews);
        }
    }
}
