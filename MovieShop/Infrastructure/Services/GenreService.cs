using ApplicationCore.Entities;
using ApplicationCore.Models.Response;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class GenreService : IGenreService
    {
        private readonly IGenreRepository _genreRepository;

        public GenreService(IGenreRepository genreRepository)
        {
            _genreRepository = genreRepository;
        }
        public async Task<IEnumerable<GenreResponseModel>> GetAllGenres()
        {
            var genres = await _genreRepository.ListAllAsync();

            var genreList = new List<GenreResponseModel>();
            foreach(var genre in genres)
            {
                genreList.Add(new GenreResponseModel { 
                    Id = genre.Id,
                    Name = genre.Name
                });
            }
            return genreList;
        }

        public async Task<List<Genre>> GetGenresByMovieId(int id)
        {
            return await _genreRepository.GetGenresByMovieId(id);
        }
    }
}
