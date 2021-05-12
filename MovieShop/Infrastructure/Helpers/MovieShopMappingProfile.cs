using ApplicationCore.Entities;
using ApplicationCore.Models.Request;
using ApplicationCore.Models.Response;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Helpers
{
    public class MovieShopMappingProfile : Profile
    {
        public MovieShopMappingProfile()
        {
            CreateMap<List<Purchase>, PurchaseResponseModel>()
                .ForMember(p => p.PurchasedMovies, opt => opt.MapFrom(src => GetPurchasedMovies(src)))
                .ForMember(p => p.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            CreateMap<List<Favorite>, FavoriteResponseModel>()
                .ForMember(p => p.FavoriteMovies, opt => opt.MapFrom(src => GetFavoriteMovies(src)))
                .ForMember(p => p.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            CreateMap<List<Review>, ReviewResponseModel>()
                .ForMember(r => r.MovieReviews, opt => opt.MapFrom(src => GetUserReviewedMovies(src)))
                .ForMember(r => r.UserId, opt => opt.MapFrom(src => src.FirstOrDefault().UserId));

            // Request Models to Db Entities Mappings
            CreateMap<PurchaseRequestModel, Purchase>();
            CreateMap<FavoriteRequestModel, Favorite>();
            CreateMap<ReviewRequestModel, Review>();
        }

        private List<PurchaseResponseModel.PurchasedMovieResponseModel> GetPurchasedMovies(
            List<Purchase> purchases)
        {
            var purchaseResponse = new PurchaseResponseModel
            {
                PurchasedMovies =
                    new List<PurchaseResponseModel.PurchasedMovieResponseModel>()
            };
            foreach (var purchase in purchases)
                purchaseResponse.PurchasedMovies.Add(new PurchaseResponseModel.PurchasedMovieResponseModel
                {
                    PosterUrl = purchase.Movie.PosterUrl,
                    PurchaseDateTime = purchase.PurchaseDateTime.Value,
                    Id = purchase.MovieId,
                    Title = purchase.Movie.Title
                });

            return purchaseResponse.PurchasedMovies;
        }

        private List<FavoriteResponseModel.FavoriteMovieResponseModel> GetFavoriteMovies(
            List<Favorite> favorites)
        {
            var favoriteResponse = new FavoriteResponseModel
            {
                FavoriteMovies = new List<FavoriteResponseModel.FavoriteMovieResponseModel>()
            };
            foreach (var favorite in favorites)
                favoriteResponse.FavoriteMovies.Add(new FavoriteResponseModel.FavoriteMovieResponseModel
                {
                    PosterUrl = favorite.Movie.PosterUrl,
                    Id = favorite.MovieId,
                    Title = favorite.Movie.Title
                });

            return favoriteResponse.FavoriteMovies;
        }

        private List<ReviewMovieResponseModel> GetUserReviewedMovies(List<Review> reviews)
        {
            var reviewResponse = new ReviewResponseModel { MovieReviews = new List<ReviewMovieResponseModel>() };

            foreach (var review in reviews)
                reviewResponse.MovieReviews.Add(new ReviewMovieResponseModel
                {
                    MovieId = review.MovieId,
                    Rating = review.Rating.Value,
                    UserId = review.UserId,
                    ReviewText = review.ReviewText
                });

            return reviewResponse.MovieReviews;
        }
    }
}
