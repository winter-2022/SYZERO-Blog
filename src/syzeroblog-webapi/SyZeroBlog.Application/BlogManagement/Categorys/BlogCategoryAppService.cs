using System;
using System.Collections.Generic;
using System.Linq;
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
    public class BlogCategoryAppService : AsyncCrudAppService<BlogCategory, BlogCategoryDto, PageAndSortQueryDto,CreateBlogCategoryDto>, IBlogCategoryAppService
    {
        private readonly IRepository<BlogCategory> _blogCateRepository;

        public BlogCategoryAppService(IRepository<BlogCategory> blogCateRepository) : base(blogCateRepository)
        {
            _blogCateRepository = blogCateRepository;
        }

      
        public override async Task<PageResultDto<BlogCategoryDto>> GetAll(PageAndSortQueryDto input)
        {
          
        
            var pp = await base.GetAll(input);
            pp.list = pp.list.Where(p => p.ParentId == null).ToList();
            return pp;
        }

        //public override Task<BlogCategoryDto> Create(BlogCategoryDto input)
        //{
        //    return base.Create(input);
        //}

  
    }
}
