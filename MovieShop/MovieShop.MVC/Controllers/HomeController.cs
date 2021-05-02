using ApplicationCore.ServiceInterface;
using Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MovieShop.MVC.Models;
using System.Diagnostics;

namespace MovieShop.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        //private MovieService _service;

        private readonly IMovieService _service;

        public HomeController(IMovieService service)
        {
            //When we use new method, this means HomeController is tight couple with MovieServie
            //_service = new MovieService();

            //Do not hard code any service in constructor which is loose couple
            //Dependency Injection is in Startup.cs ConfigureServices
            _service = service;
        }

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            var movies = _service.GetTop30RevenueMovies();

            return View(movies);
        }

        [HttpGet]
        //[Route(template:"index/year/month/jan")]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
