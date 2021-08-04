using Data.Contracts;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class PhotoRepository: GenericRepository<Photo>, IPhotoRepository
    {
        public PhotoRepository(ProjectDbContext context): base(context)
        {

        }


        public async Task<Photo> FindByURL(string url)
        {
            return await Context.Photos.Where(p => p.Url == url).SingleOrDefaultAsync();
        }
    }
}
