using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IFavoriteProductRepository : IGenericRepository<FavoriteProduct>
    {
        public Task<IEnumerable<FavoriteProduct>> GetAsync(int userId);
    }
}
