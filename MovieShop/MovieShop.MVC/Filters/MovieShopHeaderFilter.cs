using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MovieShop.MVC.Filters
{
    public class MovieShopHeaderFilter : Attribute , IActionFilter
    {
        private readonly ICurrentUserService _currentUserService;

        public MovieShopHeaderFilter(ICurrentUserService currentUserService)
        {
            _currentUserService = currentUserService;
        }
        //execute before action is executed
        public void OnActionExecuted(ActionExecutedContext context)
        {
            var email = _currentUserService.Email;
            var userId = _currentUserService.UserId;
            var fullname = _currentUserService.FullName;
            var isAuth = _currentUserService.IsAuthenticated;

            //if(!isAuth)
            //{
            //    throw new Exception("Not Authenticatd!");
            //}
        }

        //execute after action is completed
        public void OnActionExecuting(ActionExecutingContext context)
        {

        }
    }
}
