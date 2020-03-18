using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Entities;
using SyZeroBlog.Core.Files;

namespace SyZeroBlog.Core.Authorization.Users
{
    public class User  : SyZeroUser
    {
        /// <summary>
        /// 昵称
        /// </summary>
        public string NickName { get; set; }
        /// <summary>
        /// 头像文件
        /// </summary>
        public virtual File HeadPicture { get; set; }




    }
}
