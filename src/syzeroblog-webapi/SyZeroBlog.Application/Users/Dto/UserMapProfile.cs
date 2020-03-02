using AutoMapper;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Application.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>();
        }
            
    }
}
