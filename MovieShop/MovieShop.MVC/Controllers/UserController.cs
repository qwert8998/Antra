using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        public async Task<IActionResult> GetUserPurchases()
        {
            //it should look for cookie is present
            //cookie should not be expired and get the user id
            return View();
        }
    }
}
