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
    public class CastController : ControllerBase
    {
        private readonly ICastService _castService;

        public CastController(ICastService castService)
        {
            _castService = castService;
        }

        [HttpGet]
        [Route("{id:int}", Name = "")]
        public async Task<IActionResult> GetCastByMovieId (int id)
        {
            var casts = await _castService.GetCastsByMovieId(id);
            if(casts.Any())
            {
                return Ok(casts);
            }

            return NotFound("Cannot found any casts");
        }
    }
}
