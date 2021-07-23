using AutoMapper;
using Service.Models;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class CategoryAdapter
    {
        private readonly IMapper _categoryAdapter;

        public CategoryAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, Data.Models.Category>();
                config.CreateMap<Data.Models.Category, Category>();
            });

            _categoryAdapter = config.CreateMapper();
        }

        public Data.Models.Category Adapt(Category category)
        {
            return _categoryAdapter.Map<Category, Data.Models.Category>(category);
        }

        public Category Adapt(Data.Models.Category category)
        {
            return _categoryAdapter.Map<Data.Models.Category, Category>(category);
        }

        public IEnumerable<Category> AdaptList(IEnumerable<Data.Models.Category> categories)
        {
            return _categoryAdapter.Map<IEnumerable<Data.Models.Category>, IEnumerable<Category>>(categories);
        }
    }
}
