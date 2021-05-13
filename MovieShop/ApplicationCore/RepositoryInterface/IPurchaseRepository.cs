using ApplicationCore.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ApplicationCore.RepositoryInterface
{
    public interface IPurchaseRepository : IAsyncRepository<Purchase>
    {
        Task<List<Purchase>> GetAllPurchaseByUserId(int id);
        Task<List<Purchase>> GetAllPurchases();
    }
}
