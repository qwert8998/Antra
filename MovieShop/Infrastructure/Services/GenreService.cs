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
        private readonly IAsyncRepository<Genre> _genreRepository;

        public GenreService(IAsyncRepository<Genre> genreRepository)
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
    }
}
