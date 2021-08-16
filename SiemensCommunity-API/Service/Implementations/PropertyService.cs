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
    public class PropertyService : IPropertyService
    {
        private readonly IPropertyRepository _propertyRepository;
        private readonly ILogService _logService;
        private readonly PropertyAdapter _propertyAdapter = new PropertyAdapter();
        private readonly ILogger _logger;

        public PropertyService(IPropertyRepository propertyRepository,ILogService logService, ILoggerFactory logger)
        {
            _propertyRepository = propertyRepository;
            _logService = logService;
            _logger = logger.CreateLogger("PropertyService");
        }

        public async Task<IEnumerable<Property>> GetCategoryProperties(int categoryId)
        {
            IEnumerable<Property> adaptedProperties = new List<Property>();
            try
            {
                var returnedProperties = await _propertyRepository.GetCategoryProperties(categoryId);
                adaptedProperties = _propertyAdapter.AdaptList(returnedProperties);
            }
            catch (Exception ex)
            {
                _logger.LogError(MyLogEvents.ListItems, "Error while getting list of properties: {error}", ex.Message);
                await _logService.SaveAsync(LogLevel.Error, MyLogEvents.ListItems, ex.Message, ex.StackTrace);
            }
            return adaptedProperties;
        }
    }
}
