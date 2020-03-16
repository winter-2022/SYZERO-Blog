using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero;
using SyZero.Application.Service;
using SyZero.Application.Service.Dto;
using SyZero.Domain.Repository;
using SyZero.Runtime.Entities;
using SyZeroBlog.Application.BlogManagement.Categorys.Dto;
using SyZeroBlog.Core.BlogManagement.Categorys;

namespace SyZeroBlog.Application.BlogManagement.Categorys
{
    public class BlogCategoryAppService : AsyncCrudAppService<BlogCategory, BlogCategoryDto>, IBlogCategoryAppService
    {
        private readonly IRepository<BlogCategory> _blogCateRepository;

        public BlogCategoryAppService(IRepository<BlogCategory> blogCateRepository) : base(blogCateRepository)
        {
            _blogCateRepository = blogCateRepository;
        }

      
        public override Task<PageResultDto<BlogCategoryDto>> GetAll(PageAndSortQueryDto input)
        {
          
            if (SySession.UserId == null)
            {
                throw new SyMessageBox(new { code = SyMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{SyMessageBoxStatus.接口授权码无效.ToString()}" });
            }
            return base.GetAll(input);
        }

        public override Task<BlogCategoryDto> Create(BlogCategoryDto input)
        {
            return base.Create(input);
        }

  
    }
}
