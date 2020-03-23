using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Application.Service;
using SyZeroBlog.Application.Authorization.Accounts.Dto;

namespace SyZeroBlog.Application.Authorization.Accounts
{
    public interface IAccountService: IApplicationServiceBase
    {
        Task<bool> Register(RegisterInput input);
    }
}
