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
    }
}
