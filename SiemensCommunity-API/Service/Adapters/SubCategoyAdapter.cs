using AutoMapper;
using Service.Models;
using System.Collections.Generic;

namespace Service.Adapters
{
    public class SubCategoyAdapter
    {
        private readonly IMapper _subCategoryAdapeter;

        public SubCategoyAdapter()
        {
            var confing = new MapperConfiguration(confing =>
            {
                confing.CreateMap<Data.Models.SubCategory, SubCategory>();
                confing.CreateMap<SubCategory, Data.Models.SubCategory>();
            });
            _subCategoryAdapeter = confing.CreateMapper();
        }


        public Data.Models.SubCategory Adapt(SubCategory subCategory)
        {
            return _subCategoryAdapeter.Map<SubCategory, Data.Models.SubCategory>(subCategory);
        }


        public SubCategory Adapt(Data.Models.SubCategory subCategory)
        {
            return _subCategoryAdapeter.Map<Data.Models.SubCategory, SubCategory>(subCategory);
        }


        public IEnumerable<SubCategory> AdaptList(IEnumerable<Data.Models.SubCategory> subCategories)
        {
            return _subCategoryAdapeter.Map<IEnumerable<Data.Models.SubCategory>, IEnumerable<SubCategory>>(subCategories);
        }
    }
}
