using AutoMapper;
using Service.Models;

namespace Service.Adapters
{
    public class AddProductAdapter
    {

        private readonly IMapper _addProductAdapter;

        public AddProductAdapter()
        {
            var config = new MapperConfiguration(config =>
            {

                config.CreateMap<AddProductAdapter, Data.Models.AddProduct>();
                config.CreateMap<Data.Models.AddProduct, AddProductAdapter>();
            });

            _addProductAdapter = config.CreateMapper();
        }


        public Data.Models.AddProduct Adapt(AddProductAdapter product)
        {
            return _addProductAdapter.Map<AddProductAdapter, Data.Models.AddProduct>(product);
        }


        public AddProduct Adapt(Data.Models.AddProduct product)
        {
            return _addProductAdapter.Map<Data.Models.AddProduct, AddProduct>(product);
        }
    }
}
