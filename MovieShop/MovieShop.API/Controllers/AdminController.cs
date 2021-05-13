using ApplicationCore.Models.Request;
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
    public class AdminController : ControllerBase
    {
        private readonly IMovieService _movieService;

        public AdminController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        [HttpPost("movie")]
        public async Task<IActionResult> CreateMovie(CreateMovieRequest movieCreateRequest)
        {
            var created = await _movieService.CreateMovie(movieCreateRequest);
            var details = await _movieService.GetMovieDetails(created.Id);
            return CreatedAtRoute("GetMoive", new { id = created.Id }, details);
        }

        [HttpPut("movie")]
        public async Task<IActionResult> UpdateMovie(CreateMovieRequest movieCreateRequest)
        {
            var created = await _movieService.UpdateMovie(movieCreateRequest);
            var details = await _movieService.GetMovieDetails(created.Id);
            return CreatedAtRoute("GetMoive", new { id = created.Id }, details);
        }

        [HttpGet("purchases")]
        public async Task<IActionResult> GetAllPurchases()
        {
            var movies = await _movieService.GetAllMoviePurchases();
            return Ok(movies);
        }
    }
}
