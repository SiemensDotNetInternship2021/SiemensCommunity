using System.Collections.Generic;
using System.Threading.Tasks;

namespace Data.Contracts
{
    public interface IGenericRepository<T> where T : class
    {
        public Task<T> AddAsync(T entity);

        public Task<bool> DeleteByIdAsync(int id);

        public Task<IEnumerable<T>> GetAsync();

        public Task<T> UpdateAsync(T entity, int id);
    }
}
