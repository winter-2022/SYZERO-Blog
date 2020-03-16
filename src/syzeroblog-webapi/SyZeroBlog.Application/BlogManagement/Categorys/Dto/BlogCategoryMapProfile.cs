using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SyZeroBlog.Core.BlogManagement.Categorys;

namespace SyZeroBlog.Application.BlogManagement.Categorys.Dto
{
    public class BlogCategoryMapProfile : Profile
    {
        public BlogCategoryMapProfile()
        {
            CreateMap<BlogCategoryDto, BlogCategory>();
            CreateMap<BlogCategory, BlogCategoryDto>();

        }
    }
}
