using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SyZero.Application.Service;
using SyZeroBlog.Application.Users.Dto;
using SyZero.Domain.Repository;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Application.Users
{
    public class UserAppService : AsyncCrudAppService<User,UserDto>, IUserAppService
    {
        private readonly IRepository<User>  _userRepository;

        public UserAppService(IRepository<User>  userRepository):base(userRepository)
        {
            _userRepository = userRepository;
        }

        ///// <summary>
        ///// 获取用户
        ///// </summary>
        ///// <returns></returns>
        //[HttpPost]
        //public List<UserDto> GetUser()
        //{
        //    var list = _userRepository.GetList();
        //    return ObjectMapper.Map<List<UserDto>>(list);
        //}
    }
}
