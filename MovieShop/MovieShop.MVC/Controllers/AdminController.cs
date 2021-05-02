using ApplicationCore.Models.Request;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CreateMovie()
        {
            //will show empty page so that admin can enter movie information 
            return View();
        }

        [HttpPost]
        public IActionResult CreateMovie(CreateMovieRequest request)
        {
            //auto matching the name with request's properties' names
            return View();
        }
    }
}
