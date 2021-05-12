using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using AutoMapper;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IPurchaseRepository _purchaseRepository;
        private readonly IMapper _mapper;
        private readonly IMovieService _movieService;
        private readonly IFavoriteRepository _favoriteRepository;
        private readonly IReviewRepository _reviewRepository;
        public UserService(IUserRepository userRepository, IPurchaseRepository purchaseRepository
            , IMapper mapper, IMovieService movieService, IFavoriteRepository favoriteRepository
            , IReviewRepository reviewRepository)
        {
            _userRepository = userRepository;
            _purchaseRepository = purchaseRepository;
            _mapper = mapper;
            _movieService = movieService;
            _favoriteRepository = favoriteRepository;
            _reviewRepository = reviewRepository;
        }
        public async Task<UserRegisterResponseModel> RegisterUser(UserRegisterRequestModel registerRequest)
        {
            var dbUser = await _userRepository.GetUserByEmail(registerRequest.Email);

            // if   user exists
            if (dbUser != null)
            {
                throw new ConflictException("User Already exists, please try to login");
            }

            // generate a unique salt
            var salt = CreateSalt();

            // hash the password with salt generated in the above step
            var hashedPassword = CreateHashedPassword(registerRequest.Password, salt);

            // then create User Object and save it to database with UserRepository 
            var user = new User()
            {
                FirstName = registerRequest.FirstName,
                LastName = registerRequest.LastName,
                Email = registerRequest.Email,
                Salt = salt,
                HashedPassword = hashedPassword,
                DateOfBirth = registerRequest.DateTime,
            };

            // call repository to save User info that included salt and hashed password
            var createdUser = await _userRepository.AddAsync(user);

            // map user object to UserRegisterResponseModel object
            var createdUserResponse = new UserRegisterResponseModel
            {
                Id = createdUser.Id,
                Email = createdUser.Email,
                FirstName = createdUser.FirstName,
                LastName = createdUser.LastName
            };

            return createdUserResponse;
        }

        public async Task<UserLoginResponseModel> ValidateUser(string email, string password)
        {
            var dbuser = await _userRepository.GetUserByEmail(email);
            if(dbuser == null)
                return null;

            var hashedPassword = CreateHashedPassword(password, dbuser.Salt);
            if(hashedPassword == dbuser.HashedPassword)
            {
                var response = new UserLoginResponseModel() {
                    Id = dbuser.Id,
                    Email = dbuser.Email,
                    FirstName = dbuser.FirstName,
                    LastName = dbuser.LastName
                };
                return response;
            }
            return null;
        }

        private string CreateSalt()
        {
            byte[] randomBytes = new byte[128 / 8];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(randomBytes);
            }

            return Convert.ToBase64String(randomBytes);
        }

        private string CreateHashedPassword(string password, string salt)
        {
            var hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password: password,
                salt: Convert.FromBase64String(salt),
                prf: KeyDerivationPrf.HMACSHA512,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));
            return hashed;
        }

        public async Task<UserDetailsResponseModel> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);

            if(user == null)
            {
                throw new NotFoundException("User doesn't exist");
            }

            var details = new UserDetailsResponseModel() { 
                Id = user.Id,
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };

            return details;
        }

        public async Task PurchaseMovie(PurchaseRequestModel purchaseRequest)
        {
            if (await IsMoviePurchased(purchaseRequest))
                throw new ConflictException("Movie already Purchased");
            // Get Movie Price from Movie Table
            var movie = await _movieService.GetMovieDetails(purchaseRequest.MovieId);
            purchaseRequest.TotalPrice = movie.Movie.Price;

            var purchase = _mapper.Map<Purchase>(purchaseRequest);
            await _purchaseRepository.AddAsync(purchase);
        }

        public async Task<bool> IsMoviePurchased(PurchaseRequestModel purchaseRequest)
        {
            return await _purchaseRepository.GetExistsAsync(p =>
                p.UserId == purchaseRequest.UserId && p.MovieId == purchaseRequest.MovieId);
        }

        public async Task AddFavorite(FavoriteRequestModel favoriteRequest)
        {
            if (await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId))
                throw new ConflictException("Movie already Favorited");

            var favorite = _mapper.Map<Favorite>(favoriteRequest);
            await _favoriteRepository.AddAsync(favorite);
        }

        public async Task RemoveFavorite(FavoriteRequestModel favoriteRequest)
        {
            if(await FavoriteExists(favoriteRequest.UserId, favoriteRequest.MovieId))
            {
                var dbFavorite =
                await _favoriteRepository.ListAsync(r => r.UserId == favoriteRequest.UserId &&
                                                         r.MovieId == favoriteRequest.MovieId);
                await _favoriteRepository.DeleteAsync(dbFavorite.First());
            }
        }

        public async Task<bool> FavoriteExists(int id, int movieId)
        {
            return await _favoriteRepository.GetExistsAsync(f => f.MovieId == movieId &&
                                                                 f.UserId == id);
        }

        public async Task AddReview(ReviewRequestModel reviewRequest)
        {
            var review = _mapper.Map<Review>(reviewRequest);
            await _reviewRepository.AddAsync(review);
        }

        public async Task UpdateReview(ReviewRequestModel reviewRequest)
        {
            var review = _mapper.Map<Review>(reviewRequest);
            await _reviewRepository.UpdateAsync(review);
        }

        public async Task DeleteReview(int userId, int movieId)
        {
            var review = await _reviewRepository.ListAsync(r => r.UserId == userId && r.MovieId == movieId);
            await _reviewRepository.DeleteAsync(review.First());
        }

        public async Task<PurchaseResponseModel> GetAllPurchaseMoviesByUserId(int id)
        {
            var result = await _purchaseRepository.GetAllPurchaseByUserId(id);
            return _mapper.Map<PurchaseResponseModel>(result);
        }

        public async Task<FavoriteResponseModel> GetAllFavoriteByUserId(int id)
        {
            var result = await _favoriteRepository.GetAllFavoriteByUserId(id);
            return _mapper.Map<FavoriteResponseModel>(result);
        }

        public async Task<ReviewResponseModel> GetAllReviewsByUserId(int id)
        {
            var result = await _reviewRepository.GetAllReviewsByUserId(id);
            return _mapper.Map<ReviewResponseModel>(result);
        }
    }
}
