using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class PropertyAdapter
    {
        private readonly IMapper _propertyAdapter;

        public PropertyAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Property, Service.Models.Property>();
                config.CreateMap<Service.Models.Property, Property>();
            });

            _propertyAdapter = config.CreateMapper();
        }

        public Service.Models.Property Adapt(Property property)
        {
            return _propertyAdapter.Map<Property, Service.Models.Property>(property);
        }

        public Property Adapt(Service.Models.Property property)
        {
            return _propertyAdapter.Map<Service.Models.Property, Property>(property);
        }

        public IEnumerable<Property> AdaptList(IEnumerable<Service.Models.Property> property)
        {
            return _propertyAdapter.Map<IEnumerable<Service.Models.Property>, IEnumerable<Property>>(property);
        }
    }
}
