using ApplicationCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationCore.ServiceInterface
{
    public interface ICastService
    {
        Task<List<Cast>> GetCastsByMovieId(int id);
    }
}
