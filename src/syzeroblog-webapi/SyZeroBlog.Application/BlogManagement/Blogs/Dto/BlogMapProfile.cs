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
            CreateMap<Blog, BlogDto>().BeforeMap((entity, dto)
                =>
            {
                dto.CreateUserId = entity.CreateUser.Id;
                dto.CreateUserName = entity.CreateUser.Name;
                dto.CategoryId = entity.Category.Id;
                dto.CategoryName = entity.Category.Name;
            });

            CreateMap<CreateBlogDto, Blog>();
            CreateMap<Blog, CreateBlogDto>();
        }

    }
}
