using SiemensCommunity.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Models.Entities
{
    public interface IBookRepository
    {
        IEnumerable<Book> AllBooks { get; }
    }
}
