using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZero.ObjectMapper;
using SyZero.Web.Common;
using SyZeroBlog.Application.Authorization.Accounts.Dto;
using SyZeroBlog.Application.Users.Dto;
using SyZeroBlog.Core.Authorization;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Application.Authorization.Accounts
{
    public class AccountService : ApplicationService, IAccountService
    {
        private readonly RegistrationManager _registrationManager;

        private readonly ISyEncode _syEncode;
       
        public AccountService(RegistrationManager registrationManager,ISyEncode syEncode)
        {
            _registrationManager = registrationManager;
            _syEncode = syEncode;
        }
        public async Task<bool> Register(RegisterInput input)
        {
            var user =await _registrationManager.RegisterAsync(
               input.UserName,
               _syEncode.Get32MD5One(input.PassWord),
               input.Phone
                );
            return user != null;
        }
    }
}
