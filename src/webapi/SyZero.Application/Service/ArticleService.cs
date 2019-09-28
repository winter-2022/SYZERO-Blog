using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SyZero.Domain.Repository;
using SyZero.Domain.Model;
using SyZero.Common;

namespace SyZero.Application
{
    public class ArticleService : IArticleService
    {
        private readonly IRepository<Article> _articleRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleService(IRepository<Article> articleRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _articleRep = articleRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ArticleDto dto)
        {
            var article = new Article()
            {
                AddTime = DateTime.Now,
                BrowseCount = 55,
                CateId = SnowflakeId.GetID(),
                Content = "xxxxxxxxxxxxxxxxxxx",
                Description = "xxxxxxxxxxxxxxxxxxx",
                Status = 0,
                ThumbnailId = SnowflakeId.GetID(),
                Title = "asfasfas",
                Tag = "xx",
                UpdateTime = DateTime.Now,
                UserId = SnowflakeId.GetID()
            };
            _articleRep.Add(article);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _articleRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public ArticleDto GetDto(long Id)
        {
            var article = _articleRep.GetModel(Id);
            return _mapper.Map<ArticleDto>(article);
        }

        public List<ArticleDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var articlelist = _articleRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p => p.Id, u => u.Title.IndexOf(queryDto.key) > 0, false);
            return _mapper.Map<List<ArticleDto>>(articlelist);
        }

        public int Updata(ArticleDto dto)
        {
        
            return _unitOfWork.SaveChange();
        }
    }
}
