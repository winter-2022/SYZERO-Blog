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
            CreateMap<BlogCategory, BlogCategoryDto>().BeforeMap((entry, dto) => { dto.blognum = entry.Blogs == null?0: entry.Blogs.Count; });

            CreateMap<CreateBlogCategoryDto, BlogCategory>();
            CreateMap<BlogCategory, CreateBlogCategoryDto>();
        }
    }
}
