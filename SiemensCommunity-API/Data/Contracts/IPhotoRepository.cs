using Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IPhotoRepository:IGenericRepository<Photo>
    {
        public Task<Photo> FindByURL(string url);
    }
}
