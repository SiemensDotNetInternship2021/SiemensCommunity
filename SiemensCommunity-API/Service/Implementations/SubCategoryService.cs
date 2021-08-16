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
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly ILogService _logService;
        private readonly SubCategoyAdapter _subCategoyAdapter = new SubCategoyAdapter();
        private readonly ILogger _logger;

        public SubCategoryService(ISubCategoryRepository subCategoryRepository,ILogService logService, ILoggerFactory logger)
        {
            _subCategoryRepository = subCategoryRepository;
            _logService = logService;
            _logger = logger.CreateLogger("SubCategoryService");
        }

        public async Task<IEnumerable<SubCategory>> GetAsync()
        {
            IEnumerable<SubCategory> subcategoriesReturned = new List<SubCategory>();
            try
            {
                subcategoriesReturned = _subCategoyAdapter.AdaptList(await _subCategoryRepository.GetAsync());
                _logger.LogInformation(MyLogEvents.ListItems, "Got {count} subcategories.", subcategoriesReturned.Count());
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, "Error while getting the list: {error}", ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
            }
            return subcategoriesReturned;
        }
    }
}
