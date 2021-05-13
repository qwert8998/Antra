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
            return CreatedAtRoute("GetMovie", new { id = created.Id });
        }
    }
}
