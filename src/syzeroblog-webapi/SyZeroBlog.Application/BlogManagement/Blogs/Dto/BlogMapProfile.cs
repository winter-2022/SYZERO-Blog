using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SyZero;
using SyZeroBlog.Application.BlogManagement.Tags.Dto;
using SyZeroBlog.Core.BlogManagement;
using SyZeroBlog.Core.BlogManagement.Blogs;
using SyZeroBlog.Core.BlogManagement.Tags;

namespace SyZeroBlog.Application.BlogManagement.Blogs.Dto
{
   public  class BlogMapProfile : Profile
   {
       public BlogMapProfile()
       {

           CreateMap<BlogTag, TagDto>()
               .ForMember(dest => dest.Id, opt => opt.MapFrom(p => p.Tag.Id))
               .ForMember(dest => dest.Name, opt => opt.MapFrom(p => p.Tag.Name))
               .ForMember(dest => dest.Order, opt => opt.MapFrom(p => p.Tag.Order))
               .ForMember(dest => dest.Alias, opt => opt.MapFrom(p => p.Tag.Alias))
               .ForMember(dest => dest.Describe, opt => opt.MapFrom(p => p.Tag.Describe));





            CreateMap<BlogDto, Blog>();
            CreateMap<Blog, BlogDto>().BeforeMap((entity, dto)
                =>
            {
                dto.CreateUserId = entity.CreateUser?.Id;
                dto.CreateUserName = entity.CreateUser?.Name;
                dto.CategoryId = entity.Category?.Id;
                dto.CategoryName = entity.Category?.Name;
              
               
            }).ForMember(des=>des.Tags, opt => opt.MapFrom(p=>p.BlogTags))
                .ForMember(des => des.CreateTime, opt => opt.MapFrom(p => p.CreateTime.ToDateTimeFormat("yyyy-MM-dd HH:mm:ss")));
            CreateMap<CreateBlogDto, Blog>().BeforeMap((dto, entity)
                =>
            {
                if (dto.Tags!=null)
                {
                    entity.BlogTags = new List<BlogTag>();
                    entity.BlogTags.Clear();
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
