using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SyZero.Application.Service;
using SyZero.Application.Service.Dto;
using SyZero.Domain.Repository;
using SyZeroBlog.Application.BlogManagement.Blogs.Dto;
using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Core.BlogManagement.Blogs;
using SyZero.Runtime.Entities;
using SyZero;

namespace SyZeroBlog.Application.BlogManagement.Blogs
{
    public class BlogAppService : AsyncCrudAppService<Blog, BlogDto, PageAndSortQueryDto,CreateBlogDto>, IBlogAppService
    {
        private readonly IRepository<Blog>  _blogRepository;
        private readonly IRepository<User> _userRepository;
        public BlogAppService(IRepository<Blog>  blogRepository, IRepository<User> userRepository) :base(blogRepository)
        {
            _blogRepository = blogRepository;
            _userRepository = userRepository;
        }

        public override async Task<BlogDto> Create(CreateBlogDto input)
        {
            if (SySession.UserId == null)
            {
                throw new SyMessageBox(new { code = SyMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{SyMessageBoxStatus.接口授权码无效.ToString()}" });
            }
            var blog = ObjectMapper.Map<Blog>(input);

            blog.CreateUser = await _userRepository.GetModelAsync(SySession.UserId.Value);

            await _blogRepository.AddAsync(blog);

            if (await UnitOfWork.SaveAsyncChange() > 0)
            {
                return ObjectMapper.Map<BlogDto>(blog);
            }
            else
            {
                return null;
            }
        }

      
    }
}
