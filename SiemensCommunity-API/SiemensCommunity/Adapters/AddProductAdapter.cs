using AutoMapper;
using SiemensCommunity.Models;

namespace SiemensCommunity.Adapters
{
    public class AddProductAdapter
    {
        private readonly IMapper _addProductAdapter;

        public AddProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<AddProduct, Service.Models.AddProduct>()
                .ForMember(des => des.File, act => act.MapFrom(src => src.Files[0]));
                config.CreateMap<Service.Models.AddProduct, AddProduct>();
            });

            _addProductAdapter = config.CreateMapper();
        }

        public Service.Models.AddProduct Adapt(AddProduct product)
        {
            return _addProductAdapter.Map<AddProduct, Service.Models.AddProduct>(product);
        }

        public AddProduct Adapt(Service.Models.AddProduct product)
        {
            return _addProductAdapter.Map<Service.Models.AddProduct, AddProduct>(product);
        }
    }
}
