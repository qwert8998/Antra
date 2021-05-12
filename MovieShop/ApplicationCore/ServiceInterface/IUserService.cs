using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterface
{
    public interface IUserService
    {
        Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest);
        Task<UserLoginResponseModel> ValidateUser(string email, string password);
        Task<UserDetailsResponseModel> GetUserById(int id);
        Task PurchaseMovie(PurchaseRequestModel purchaseRequest);
        Task AddFavorite(FavoriteRequestModel favoriteRequest);
        Task RemoveFavorite(FavoriteRequestModel favoriteRequest);
        Task<bool> FavoriteExists(int id, int movieId);
        Task AddReview(ReviewRequestModel reviewRequest);
        Task UpdateReview(ReviewRequestModel reviewRequest);
        Task DeleteReview(int userId, int movieId);
        Task<PurchaseResponseModel> GetAllPurchaseMoviesByUserId(int id);
        Task<FavoriteResponseModel> GetAllFavoriteByUserId(int id);
        Task<ReviewResponseModel> GetAllReviewsByUserId(int id);
    }
}
