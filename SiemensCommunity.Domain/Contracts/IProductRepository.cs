using SiemensCommunity.Domain.Models.Entities;
using System.Collections.Generic;

namespace SiemensCommunity.Domain.Contracts
{
    public interface IProductRepository
    {
        IEnumerable<Product> AllProducts { get; }
    }
}
