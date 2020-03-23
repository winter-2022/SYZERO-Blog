using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using SyZeroBlog.Core.BlogManagement.Comments;

namespace SyZeroBlog.Application.BlogManagement.Comments.Dto
{
    public class CommentMapProfile : Profile
    {
        public CommentMapProfile()
        {
            CreateMap<Comment, CommentDto>();
            CreateMap<CommentDto, Comment>();
        }
    }
}
