﻿using Data.Contracts;
using Service.Adapters;
using Service.Contracts;
using Service.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Implementations
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountReposistory;
        private readonly UserAdapter _userAdapter = new UserAdapter();

        public AccountService(IAccountRepository accountReposistory)
        {
            _accountReposistory = accountReposistory;   
        }

        public async Task<int> RegisterAsync(UserRegisterCredentials userCredentials)
        {
            var returnedUser = await _accountReposistory.RegisterAsync(_userAdapter.AdaptToUserIdentity(userCredentials), userCredentials.Password);
            return returnedUser;
        }

        public async Task<bool> VerifyLoginAsync(UserLoginCredentials user)
        {
            var returned = await _accountReposistory.VerifyLoginAsync(_userAdapter.AdaptFromUserData(user));
            return returned;
        }
    }
}
