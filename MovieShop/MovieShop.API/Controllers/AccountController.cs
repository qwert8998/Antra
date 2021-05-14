using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using ApplicationCore.Models.Response;
using System.Security.Claims;
using Microsoft.Extensions.Configuration;
using System.Text;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly IConfiguration _configuration;

        public AccountController(IUserService userService, IConfiguration configuration)
        {
            _userService = userService;
            _configuration = configuration;
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

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login (UserLoginRequestModel requestModel)
        {
            var user = await _userService.ValidateUser(requestModel.Email, requestModel.Password);
            if(user != null)
            {
                //if user enter valid un/pw
                //create JWT Token
                var token = GenerateJWT(user);
                return Ok(new { token = token });
            }

            //return ValidationProblem("Email or Password is incorrect!");
            return Unauthorized();
        }

        private string GenerateJWT(UserLoginResponseModel model)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.NameIdentifier, model.Id.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, model.Email),
                new Claim(JwtRegisteredClaimNames.GivenName, model.FirstName),
                new Claim(JwtRegisteredClaimNames.FamilyName, model.LastName)
            };
            var identityClaims = new ClaimsIdentity();
            identityClaims.AddClaims(claims);

            //read the secret key from appsettings, make sure secret key is unique and not guessable
            //In real world we use something like Azure KeyValue to store any secrets of application
            var secretKey = _configuration["JwtSettings:SecretKey"];
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(secretKey));

            //get the expiration time of token
            var expires = DateTime.UtcNow.AddDays(_configuration.GetValue<int>("JwtSettings:Expiration"));

            //pick an hashing algorithm
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);

            //create the token objects that you will use to store all information
            var tokenHandler = new JwtSecurityTokenHandler();

            var tokenDescriptor = new SecurityTokenDescriptor() { 
                Subject = identityClaims,
                Expires = expires,
                SigningCredentials = credentials,
                Issuer = _configuration["JwtSettings:Issuer"],
                Audience = _configuration["JwtSettings:Audience"]
            };

            var encodeJWT = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(encodeJWT);
        }
    }
}
