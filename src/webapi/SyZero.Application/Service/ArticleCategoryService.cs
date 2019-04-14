using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SyZero.Domain.Repository;
using SyZero.Domain.Model;

namespace SyZero.Application
{
    public class ArticleCategoryService:IArticleCategoryService
    {
        private readonly IRepository<ArticleCategory> _articlectyRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ArticleCategoryService(IRepository<ArticleCategory> articlectyRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _articlectyRep = articlectyRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool Add(ArticleCategoryDto dto)
        {
            var articlecty = _mapper.Map<ArticleCategory>(dto);
            _articlectyRep.Add(articlecty);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _articlectyRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public ArticleCategoryDto GetDto(string Id)
        {
            var articlecty = _articlectyRep.GetModel(Id);
            return _mapper.Map<ArticleCategoryDto>(articlecty);
        }

        public List<ArticleCategoryDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var articlectylist = _articlectyRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p => p.Id, u => u.Name.IndexOf(queryDto.key) > 0, false);
            return _mapper.Map<List<ArticleCategoryDto>>(articlectylist);
        }

        public int Updata(ArticleCategoryDto dto)
        {
            var articlecty = _mapper.Map<ArticleCategory>(dto);
            var newarticlecty = _articlectyRep.GetModel(articlecty.Id);
            newarticlecty.UpDate(articlecty);
            _articlectyRep.Update(newarticlecty);
            return _unitOfWork.SaveChange();
        }
    }
}
