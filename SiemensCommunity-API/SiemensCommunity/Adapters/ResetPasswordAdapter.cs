using AutoMapper;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class ResetPasswordAdapter
    {
        private readonly IMapper _resetPasswordAdapter;

        public ResetPasswordAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ResetPassword, Service.Models.ResetPassword>();
                config.CreateMap<Service.Models.ResetPassword, ResetPassword>();
            });

            _resetPasswordAdapter = config.CreateMapper();
        }

        public Service.Models.ResetPassword Adapt(ResetPassword resetPassword)
        {
            return _resetPasswordAdapter.Map<ResetPassword, Service.Models.ResetPassword>(resetPassword);
        }

        public ResetPassword Adapt(Service.Models.ResetPassword resetPassword)
        {
            return _resetPasswordAdapter.Map<Service.Models.ResetPassword, ResetPassword>(resetPassword);
        }
    }
}
