using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")] //attribute-based routing
    [ApiController]
    public class GenreController : ControllerBase
    {
        //API controller is different from controller in MVC
        //1. Using Controllerbase since it does not need to return view

        private readonly IGenreService _genreService;

        public GenreController(IGenreService genreService)
        {
            _genreService = genreService;
        }

        [HttpGet]
        [Route("")]
        public async Task<IActionResult> GetAllGenres()
        {
            //remember the http status codes
            var genres = await _genreService.GetAllGenres();
            
            if(genres.Any())
            {
                return Ok(genres);
            }

            return NotFound("No genre found");
        }
    }
}
