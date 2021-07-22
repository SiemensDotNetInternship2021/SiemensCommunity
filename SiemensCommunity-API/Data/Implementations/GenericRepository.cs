using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class GenericRepository<T> where T : class
    {
        protected readonly ProjectDbContext Context;

        protected GenericRepository(ProjectDbContext context)
        {
            Context = context;
        }

        public virtual async Task<T> AddAsync(T entity)
        {
            var result = Context.Set<T>().Add(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<bool> DeleteByIdAsync(int id)
        {
            var entity = Context.Set<T>().Find(id);
            Context.Set<T>().Remove(entity);
            var saveResult = await Context.SaveChangesAsync();
            if (saveResult == 1)
            {
                return true;
            }
            else
                return false;
        }

        public virtual async Task<IEnumerable<T>> GetAsync()
        {
            return await Context.Set<T>().ToListAsync();
        }

        public virtual async Task<T> UpdateAsync(T entity, int id)
        {
            var existing = Context.Set<T>().Find(id);
            Context.Entry(existing).CurrentValues.SetValues(entity);
            await Context.SaveChangesAsync();
            return entity;
        }

    }

}
