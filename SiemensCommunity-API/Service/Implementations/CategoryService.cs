using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
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
        private readonly CategoryAdapter _categoryAdapter= new CategoryAdapter();
        private readonly ILogger _logger;
        public CategoryService(ICategoryRepository categoryRepository, ILoggerFactory logger)
        {
            _categoryRepository = categoryRepository;
            _logger = logger.CreateLogger("CategoryService");
        }

        public async Task<Category> AddAsync(Category category)
        {
            var returnedCategory = await _categoryRepository.AddAsync(_categoryAdapter.Adapt(category));
            return _categoryAdapter.Adapt(returnedCategory);
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            var categories = await _categoryRepository.GetAsync();
            _logger.LogInformation(MyLogEvents.ListItems, "Getting list of categories, {count} found.", categories.Count());
            return _categoryAdapter.AdaptList(categories);
        }
    }
}
