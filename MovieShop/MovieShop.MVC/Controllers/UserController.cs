using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MovieShop.MVC.Filters;
using System.Threading.Tasks;

namespace MovieShop.MVC.Controllers
{
    public class UserController : Controller
    {
        //use filter in specific action
        //[ServiceFilter(typeof(MovieShopHeaderFilter))]
        [Authorize]
        public async Task<IActionResult> GetUserPurchases()
        {
            //it should look for cookie is present
            //cookie should not be expired and get the user id
            
            
            return View("Purchases");
        }
    }
}
