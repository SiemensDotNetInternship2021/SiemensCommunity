using Common;
using Data.Contracts;
using Microsoft.Extensions.Logging;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;



namespace Service.Implementations
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        private readonly ILogService _logService;
        private readonly CategoryAdapter _categoryAdapter = new CategoryAdapter();
        private readonly ILogger _logger;

        public CategoryService(ICategoryRepository categoryRepository,ILogService logService, ILoggerFactory logger)
        {
            _categoryRepository = categoryRepository;
            _logService = logService;
            _logger = logger.CreateLogger("CategoryService");
        }

        public async Task<Category> AddAsync(Category category)
        {
            Category categoryAdded = new Category();
            try
            {
                var returnedCategory = await _categoryRepository.AddAsync(_categoryAdapter.Adapt(category));
                categoryAdded = _categoryAdapter.Adapt(returnedCategory);
            }catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.InsertItem, ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.InsertItem, ex.Message, ex.StackTrace);
            }
            return categoryAdded;
        }

        public async Task<IEnumerable<Category>> GetAsync()
        {
            IEnumerable<Category> categoriesAdapeted = new List<Category>();
            try
            {
                var categories = await _categoryRepository.GetAsync();
                categoriesAdapeted = _categoryAdapter.AdaptList(categories);

            }catch(Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
            }
            return categoriesAdapeted;
        }
    }
}
