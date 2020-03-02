using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using SyZero.Application.Service;
using SyZero.Domain.Repository;
using SyZeroBlog.Application.BlogManagement.Blogs.Dto;
using SyZeroBlog.Core.BlogManagement.Blogs;

namespace SyZeroBlog.Application.BlogManagement.Blogs
{
    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto>, IBlogAppService
    {
        private readonly IRepository<Blog>  _blogRepository;

        public BlogAppService(IRepository<Blog>  blogRepository):base(blogRepository)
        {
            _blogRepository = blogRepository;
        }

    }
}
