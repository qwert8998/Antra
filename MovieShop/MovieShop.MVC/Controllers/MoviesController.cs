using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class MoviesController : Controller
    {
        public async Task<IActionResult> Details(int id)
        {
            return View();
        }

        public async Task<IActionResult> GetMoviesByGenre (int id)
        {
            return View("~/Views/Home/Index.cshtml");
        }
    }
}
