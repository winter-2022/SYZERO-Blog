using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service;
using SyZero.Domain.Repository;
using SyZeroBlog.Application.BlogManagement.Comments.Dto;
using SyZeroBlog.Core.BlogManagement.Comments;

namespace SyZeroBlog.Application.BlogManagement.Comments
{
    public class CommentAppService : AsyncCrudAppService<Comment, CommentDto>, ICommentAppService
    {
        private readonly IRepository<Comment> _commentRepository;
        public CommentAppService(IRepository<Comment> commentRepository):base(commentRepository)
        {
            _commentRepository = commentRepository;
        }
    }
}
