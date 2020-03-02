using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service.Dto;

namespace SyZeroBlog.Application.Users.Dto
{
   public  class LoginDto : EntityDto
    {
        public string username { get; set; } = "";
        public string password { get; set; } = "";
    }
}
