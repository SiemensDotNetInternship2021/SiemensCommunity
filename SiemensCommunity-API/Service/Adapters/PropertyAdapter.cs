using AutoMapper;
using System;
using System.Collections.Generic;
using Service.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class PropertyAdapter
    {
        private readonly IMapper _propertyAdapter;
        public PropertyAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Property, Data.Models.Property>();
                config.CreateMap<Data.Models.Property, Property>();
            });
            _propertyAdapter = config.CreateMapper();
        }

        public Data.Models.Property Adapt(Property property)
        {
            return _propertyAdapter.Map<Property, Data.Models.Property>(property);
        }

        public Property Adapt(Data.Models.Property property)
        {
            return _propertyAdapter.Map<Data.Models.Property, Property>(property);
        }
        public IEnumerable<Property> AdaptList(IEnumerable<Data.Models.Property> property)
        {
            return _propertyAdapter.Map<IEnumerable<Data.Models.Property>, IEnumerable<Property>>(property);
        }
        public IEnumerable<Data.Models.Property> AdaptList(IEnumerable<Property> property)
        {
            return _propertyAdapter.Map<IEnumerable<Property>, IEnumerable<Data.Models.Property>>(property);
        }
    }
}
