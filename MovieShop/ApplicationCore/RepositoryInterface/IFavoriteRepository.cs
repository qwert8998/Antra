using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IFavoriteRepository : IAsyncRepository<Favorite>
    {
        Task<List<Favorite>> GetAllFavoriteByUserId(int id);
    }
}
