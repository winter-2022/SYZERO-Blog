using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service;
using SyZero.Domain.Repository;
using SyZeroBlog.Application.BlogManagement.Tags.Dto;
using SyZeroBlog.Core.BlogManagement.Tags;

namespace SyZeroBlog.Application.BlogManagement.Tags
{
    public class TagAppService : AsyncCrudAppService<Tag, TagDto>, ITagAppService
    {
        private readonly IRepository<Tag> _tagRepository;
        public TagAppService(IRepository<Tag> tagRepository):base(tagRepository)
        {
            _tagRepository = tagRepository;
        }
        
    }
}
