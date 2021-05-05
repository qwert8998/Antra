using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovieService _movieService;

        public MoviesController(IMovieService movieService)
        {
            _movieService = movieService;
        }

        public async Task<IActionResult> Details(int id)
        {
            var model = await _movieService.GetMovieDetails(id);
            return View(model);
        }

        public async Task<IActionResult> GetMoviesByGenre (int id)
        {
            var model = await _movieService.GetMoviesByGenre(id);
            return View("~/Views/Home/Index.cshtml",model);
        }
    }
}
