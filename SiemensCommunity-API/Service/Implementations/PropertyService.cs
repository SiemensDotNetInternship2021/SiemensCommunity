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
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly PropertyAdapter _propertyAdapter = new PropertyAdapter();

        public PropertyService(IPropertyRepository propertyRepository)
        {
            _propertyRepository = propertyRepository;
        }
        public async Task<IEnumerable<Property>> GetCategoryProperties(int categoryId)
        {
            var properties = await _propertyRepository.GetCategoryProperties(categoryId);
            return _propertyAdapter.AdaptList(properties);
        }
    }
}
