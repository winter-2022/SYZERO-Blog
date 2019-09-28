using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SyZero.Domain.Model;

namespace SyZero.Application
{
    public class AutoMapperConfigs:Profile
    {
        //添加你的实体映射关系.
        public AutoMapperConfigs()
        {
            //Article转ArticleDto
            CreateMap<Article, ArticleDto>().ForMember(dto => dto.Id, model => model.MapFrom(m => m.Status));
            //ArticleDto转Article
            CreateMap<ArticleDto, Article>();

            CreateMap<User, UserDto>();
            CreateMap<UserDto, User>();

       
        }

    }
}
