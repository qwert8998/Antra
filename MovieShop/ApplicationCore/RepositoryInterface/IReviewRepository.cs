using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IReviewRepository : IAsyncRepository<Review>
    {
        Task<List<Review>> GetAllReviewsByUserId(int id);
    }
}
