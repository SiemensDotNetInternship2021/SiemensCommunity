using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using SiemensCommunity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SiemensCommunity.Adapters
{
    public class ForgotPasswordAdapter : Controller
    {
        private readonly IMapper _forgotPasswordAdapter;

        public ForgotPasswordAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ForgotPassword, Service.Models.ForgotPassword>();
                config.CreateMap<Service.Models.ForgotPassword, ForgotPassword>();
            });

            _forgotPasswordAdapter = config.CreateMapper();
        }

        public Service.Models.ForgotPassword Adapt(ForgotPassword forgotPassword)
        {
            return _forgotPasswordAdapter.Map<ForgotPassword, Service.Models.ForgotPassword>(forgotPassword);
        }

        public ForgotPassword Adapt(Service.Models.ForgotPassword forgotPassword)
        {
            return _forgotPasswordAdapter.Map<Service.Models.ForgotPassword, ForgotPassword>(forgotPassword);
        }
    }
}
