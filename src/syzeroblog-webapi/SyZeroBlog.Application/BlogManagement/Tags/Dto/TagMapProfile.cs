using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using SyZeroBlog.Core.BlogManagement.Tags;

namespace SyZeroBlog.Application.BlogManagement.Tags.Dto
{
    public class TagMapProfile : Profile
    {
        public TagMapProfile()
        {
            CreateMap<TagDto, Tag>();
            CreateMap<Tag, TagDto>();
        }

    }
   
}
