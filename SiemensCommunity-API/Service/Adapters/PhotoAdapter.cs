using AutoMapper;
using Service.Models;

namespace Service.Adapters
{
    public class PhotoAdapter
    {
        private readonly IMapper _photoAdapter;
        public PhotoAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<Data.Models.Photo, Photo>();
                config.CreateMap<Photo, Data.Models.Photo>();
            });
            _photoAdapter = config.CreateMapper();
        }

        public Data.Models.Photo Adapt(Photo photo)
        {
            return _photoAdapter.Map<Photo, Data.Models.Photo>(photo);
        }

        public Photo Adapt(Data.Models.Photo photo)
        {
            return _photoAdapter.Map<Data.Models.Photo, Photo>(photo);
        }
    }
}
