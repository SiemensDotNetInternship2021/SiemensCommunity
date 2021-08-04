using AutoMapper;
using Service.Models;

namespace Service.Adapters
{
    public class ProductFormAdapter
    {
        private readonly IMapper _productFormDTOAdapter;
        public ProductFormAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Models.Category, Category>();
                config.CreateMap<Data.Models.SubCategory, SubCategory>();
                config.CreateMap<ProductFormDTO, Data.Models.ProductFormDTO>()
                .ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category))
                .ForMember(dest => dest.SubCategory, act => act.MapFrom(src => src.Subcategory));
                config.CreateMap<Data.Models.ProductFormDTO, ProductFormDTO>()
                .ForMember(dest => dest.Category, act => act.MapFrom(src => src.Category))
                .ForMember(dest => dest.Subcategory, act => act.MapFrom(src => src.SubCategory));
            });
            _productFormDTOAdapter = config.CreateMapper();
        }

        public ProductFormDTO Adapt(Data.Models.ProductFormDTO product)
        {
            return _productFormDTOAdapter.Map<Data.Models.ProductFormDTO, ProductFormDTO>(product);
        }
        public Data.Models.ProductFormDTO Adapt(ProductFormDTO product)
        {
            return _productFormDTOAdapter.Map<ProductFormDTO, Data.Models.ProductFormDTO>(product);
        }
    }
}
