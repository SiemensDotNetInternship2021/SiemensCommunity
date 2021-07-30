using Data.Contracts;
using Service.Adapters;
using Service.Models;
using Service.Contracts;
using Service.Models;
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

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> AddAsync(Category category)
        {
            var returnedCategory = await _categoryRepository.AddAsync(_categoryAdapter.Adapt(category));
            return _categoryAdapter.Adapt(returnedCategory);
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var returnedCategories = await _categoryRepository.GetAsync();
            return _categoryAdapter.AdaptList(returnedCategories);
        }
    }
}
