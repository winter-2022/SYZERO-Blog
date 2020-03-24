using AutoMapper;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Application.Users.Dto
{
    public class UserMapProfile : Profile
    {
        public UserMapProfile()
        {
            CreateMap<UserDto, User>();
            CreateMap<User, UserDto>()
                .ForMember(dest => dest.AddTime, opt => opt.MapFrom(p => p.AddTime.ToString("yyyy-MM-dd HH:mm:ss")))
                .ForMember(dest => dest.LastTime, opt => opt.MapFrom(p => p.LastTime == null ? "" : p.LastTime.Value.ToString("yyyy-MM-dd HH:mm:ss")));
        }

    }
}
