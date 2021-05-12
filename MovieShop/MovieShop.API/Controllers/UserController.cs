using ApplicationCore.Models.Request;
using ApplicationCore.ServiceInterface;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace MovieShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("purchase")]
        public async Task<IActionResult> PerchaseMovie (PurchaseRequestModel purchaseRequest)
        {
            await _userService.PurchaseMovie(purchaseRequest);
            return Ok();
        }

        [HttpPost]
        [Route("favorite")]
        public async Task<IActionResult> AddFavorite (FavoriteRequestModel favoriteRequest)
        {
            await _userService.AddFavorite(favoriteRequest);
            return Ok();
        }

        [HttpPost]
        [Route("unfavorite")]
        public async Task<IActionResult> RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            await _userService.RemoveFavorite(favoriteRequest);
            return Ok();
        }

        [HttpGet]
        [Route("{id:int}/movie/{movieId}/favorite")]
        public async Task<ActionResult> IsFavoriteExists(int id, int movieId)
        {
            var favoriteExists = await _userService.FavoriteExists(id, movieId);
            return Ok(new { isFavorited = favoriteExists });
        }

        [HttpPost]
        [Route("review")]
        public async Task<ActionResult> CreateReview(ReviewRequestModel reviewRequest)
        {
            await _userService.AddReview(reviewRequest);
            return Ok();
        }

        [HttpPut]
        [Route("review")]
        public async Task<ActionResult> UpdateReview(ReviewRequestModel reviewRequest)
        {
            await _userService.UpdateReview(reviewRequest);
            return Ok();
        }

        [HttpDelete]
        [Route("{userId:int}/movie/{movieId:int}")]
        public async Task<IActionResult> DeleteReview(int userId, int movieId)
        {
            await _userService.DeleteReview(userId,movieId);
            return NoContent();
        }

        [HttpGet]
        [Route("{id:int}/purchases")]
        public async Task<IActionResult> GetAllPurchase (int id)
        {
            var purchases = await _userService.GetAllPurchaseMoviesByUserId(id);
            return Ok(purchases);
        }

        [HttpGet]
        [Route("{id:int}/favorties")]
        public async Task<IActionResult> GetAllFavorite(int id)
        {
            var favorites = await _userService.GetAllFavoriteByUserId(id);
            return Ok(favorites);
        }

        [HttpGet]
        [Route("{id:int}/reviews")]
        public async Task<IActionResult> GetAllReviews(int id)
        {
            var reviews = await _userService.GetAllReviewsByUserId(id);
            return Ok(reviews);
        }
    }
}
