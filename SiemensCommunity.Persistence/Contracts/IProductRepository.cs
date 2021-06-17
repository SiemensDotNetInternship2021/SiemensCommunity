using SiemensCommunity.Persistence.Models.Entities;
using System.Collections.Generic;

namespace SiemensCommunity.Persistence.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
    }
}
