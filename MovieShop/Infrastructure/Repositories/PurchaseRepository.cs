using ApplicationCore.Entities;
using ApplicationCore.RepositoryInterface;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class PurchaseRepository : EfRepository<Purchase>, IPurchaseRepository
    {
        public PurchaseRepository(MovieShopDBContext dbContext) : base(dbContext)
        {
        }

        public async Task<List<Purchase>> GetAllPurchaseByUserId(int id)
        {
            var result = await _dbContext.Purchases.Include(p => p.Movie).Where(p => p.UserId == id).ToListAsync();
            return result;
        }

        public async Task<List<Purchase>> GetAllPurchases ()
        {
            var result = await _dbContext.Purchases.Include(p => p.Movie).ToListAsync();
            return result;
        }
    }
}
