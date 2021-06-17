using SiemensCommunity.Model.Entities;
using SiemensCommunity.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Models.Mocks
{
    public class MockBookRepository : IBookRepository
    {
        public IEnumerable<Book> AllBooks =>
            new List<Book>
            {
                new Book{Id = 1, Name = "GameOfThrones", Author = "author1", Category = "SF", Owner = "owner1"},
                new Book{Id = 2, Name = "GameOfThrones2", Author = "author1", Category = "SF", Owner = "owner1342"},
                new Book{Id = 3, Name = "GameOfThrones3", Author = "author1", Category = "SF", Owner = "owner132"},
                new Book{Id = 4, Name = "GameOfThrones4", Author = "author1", Category = "SF", Owner = "owner16456"},
            };
    }
}
