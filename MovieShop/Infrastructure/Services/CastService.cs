using ApplicationCore.Entities;
using ApplicationCore.Exceptions;
using ApplicationCore.RepositoryInterface;
using ApplicationCore.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class CastService : ICastService
    {
        private readonly ICastRepository _castRepository;

        public CastService (ICastRepository castRepository)
        {
            _castRepository = castRepository;
        }

        public async Task<List<Cast>> GetCastsByMovieId(int id)
        {
            var casts = await _castRepository.GetCastsByMovieId(id);
            if(casts == null)
            {
                throw new NotFoundException("Not found any casts!");
            }

            return casts;
        }
    }
}
