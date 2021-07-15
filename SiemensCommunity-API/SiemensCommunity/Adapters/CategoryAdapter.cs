using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class CategoryAdapter
    {
        private readonly IMapper _categoryAdapter;

        public CategoryAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, Service.Models.Category>();
                config.CreateMap<Service.Models.Category, Category>();
            });

            _categoryAdapter = config.CreateMapper();
        }

        public Service.Models.Category Adapt(Category category)
        {
            return _categoryAdapter.Map<Category, Service.Models.Category>(category);
        }

        public Category Adapt(Service.Models.Category category)
        {
            return _categoryAdapter.Map<Service.Models.Category, Category>(category);
        }

        public IEnumerable<Category> AdaptList(IEnumerable<Service.Models.Category> category)
        {
            return _categoryAdapter.Map<IEnumerable<Service.Models.Category>, IEnumerable<Category>>(category);
        }
    }
}
