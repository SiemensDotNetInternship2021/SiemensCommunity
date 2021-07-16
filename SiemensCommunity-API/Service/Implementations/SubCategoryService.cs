using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class SubCategoryService : ISubCategoryService
    {
        private readonly ISubCategoryRepository _subCategoryRepository;
        private readonly SubCategoyAdapter _subCategoyAdapter = new SubCategoyAdapter();

        public SubCategoryService(ISubCategoryRepository subCategoryRepository)
        {
            _subCategoryRepository = subCategoryRepository;
        }
        public async Task<IEnumerable<SubCategory>> GetAsync()
        {
            var subCategories = await _subCategoryRepository.GetAsync();
            return _subCategoyAdapter.AdaptList(subCategories);
        }
    }
}
