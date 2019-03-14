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
           // CreateMap<ArticleDto, Article>().ForMember(sou => sou.Status, dto => dto.MapFrom(p => p.Status == "发布" ? 1 : 0));
        }
    
    }
}
