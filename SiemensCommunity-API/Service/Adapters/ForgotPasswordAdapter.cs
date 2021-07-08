using AutoMapper;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Adapters
{
    public class ForgotPasswordAdapter
    {
        private readonly IMapper _forgotPasswordAdapter;

        public ForgotPasswordAdapter()
        {
            var config = new MapperConfiguration(config =>
            {
                config.CreateMap<ForgotPassword, Data.Models.ForgotPassword>();
                config.CreateMap<Data.Models.ForgotPassword, ForgotPassword>();
            });

            _forgotPasswordAdapter = config.CreateMapper();
        }

        public Data.Models.ForgotPassword Adapt(ForgotPassword forgotPassword)
        {
            return _forgotPasswordAdapter.Map<ForgotPassword, Data.Models.ForgotPassword>(forgotPassword);
        }

        public ForgotPassword Adapt(Data.Models.ForgotPassword forgotPassword)
        {
            return _forgotPasswordAdapter.Map<Data.Models.ForgotPassword, ForgotPassword>(forgotPassword);
        }

        public IEnumerable<ForgotPassword> AdaptList(IEnumerable<Data.Models.ForgotPassword> forgotPasswords)
        {
            return _forgotPasswordAdapter.Map<IEnumerable<Data.Models.ForgotPassword>, IEnumerable<ForgotPassword>>(forgotPasswords);
        }
    }
}
