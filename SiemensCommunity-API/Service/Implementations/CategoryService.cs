using Data.Contracts;
using Service.Adapters;
using Service.Models;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly CategoryAdapter _categoryAdapter = new CategoryAdapter();

        public CategoryService(ICategoryRepository _categoryAdapter)
        {
            _categoryRepository = _categoryAdapter;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var returnedCategories = await _categoryRepository.GetAsync();
            return _categoryAdapter.AdaptList(returnedCategories);
        }
    }
}
