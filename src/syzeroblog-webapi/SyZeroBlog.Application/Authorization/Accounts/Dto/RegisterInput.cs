using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;

namespace SyZeroBlog.Application.Authorization.Accounts.Dto
{
    public class RegisterInput:EntityDto
    {
        public string UserName { get; set; }
        public string PassWord { get; set; }

        public string Phone { get; set; }
    }
}
