using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SyZero;
using SyZeroBlog.Core.BlogManagement;
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
                dto.CreateUserId = entity.CreateUser?.Id;
                dto.CreateUserName = entity.CreateUser?.Name;
                dto.CategoryId = entity.Category?.Id;
                dto.CategoryName = entity.Category?.Name;
            });

            CreateMap<CreateBlogDto, Blog>().BeforeMap((dto, entity)
                =>
            {
                if (dto.Tags!=null)
                {
                    entity.BlogTags = new List<BlogTag>();
                    foreach (var tags in dto.Tags)
                    {
                        entity.BlogTags.Add(new Core.BlogManagement.BlogTag() { BlogId = entity.Id, TagId = tags.ToLong() });
                    }
                }
              
            });
            CreateMap<Blog, CreateBlogDto>();
        }

    }
}
