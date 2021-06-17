using SiemensCommunity.Persistence.Contracts;
using SiemensCommunity.Persistence.Models.Entities;
using System.Collections.Generic;

namespace SiemensCommunity.Domain.Mocks
{
    public class MockProductRepository : IProductRepository
    {
        public IEnumerable<Product> AllProducts =>
            new List<Product>
            {
                new Product{Id = 1, Name = "GameOfThrones"},
                new Product{Id = 2, Name = "GameOfThrones2"},
                new Product{Id = 3, Name = "GameOfThrones3"},
                new Product{Id = 4, Name = "GameOfThrones4"}
            };
    }
}
