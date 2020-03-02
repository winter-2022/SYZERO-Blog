using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SyZeroBlog.Core.BlogManagement.Blogs;
namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
   public  class BlogMapProfile : Profile
    {
        public BlogMapProfile()
        {
            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>();
      
        }

    }
}
