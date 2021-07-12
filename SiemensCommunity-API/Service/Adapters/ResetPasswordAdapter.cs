using AutoMapper;
using Service.Models;

namespace Service.Adapters
{
    public class ResetPasswordAdapter
    {
        private readonly IMapper _resetPasswordAdapter;

        public ResetPasswordAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ResetPassword, Data.Models.ResetPassword>();
                config.CreateMap<Data.Models.ResetPassword, ResetPassword>();
            });

            _resetPasswordAdapter = config.CreateMapper();
        }

        public Data.Models.ResetPassword Adapt(ResetPassword resetPassword)
        {
            return _resetPasswordAdapter.Map<ResetPassword, Data.Models.ResetPassword>(resetPassword);
        }

        public ResetPassword Adapt(Data.Models.ResetPassword resetPassword)
        {
            return _resetPasswordAdapter.Map<Data.Models.ResetPassword, ResetPassword>(resetPassword);
        }
    }
}
