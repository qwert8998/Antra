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
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("")]
        public async Task<IActionResult> RegisterAccount(UserRegisterRequestModel model)
        {
            var user = await _userService.RegisterUser(model);

            return CreatedAtRoute("GetUser", new { id = user.Id}, user);
        }

        [HttpGet]
        [Route("{id:int}",Name = "GetUser")]
        public async Task<IActionResult>GetUserById (int id)
        {
            var user = await _userService.GetUserById(id);
            return Ok(user);
        }
    }
}
