using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Dto;
using SyZero.Application.Interface;
using SyZero.Domain.Interface;
using SyZero.Domain.Model;


namespace SyZero.Application.Service
{
    public class SiteConfigService : ISiteConfigService
    {
        private readonly IEfRepository<SiteConfig> _siteconfigRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public SiteConfigService(IEfRepository<SiteConfig> siteconfigRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _siteconfigRep = siteconfigRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public bool Add(SiteConfigDto dto)
        {
            var siteconfig = _mapper.Map<SiteConfig>(dto);
            _siteconfigRep.Add(siteconfig);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _siteconfigRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public SiteConfigDto GetDto(string Id)
        {
            var siteconfig = _siteconfigRep.GetModel(long.Parse(Id));
            return _mapper.Map<SiteConfigDto>(siteconfig);
        }

        public List<SiteConfigDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var commentlist = _siteconfigRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p => p.Id, u => u.Key.IndexOf(queryDto.key) > 0, false);
            return _mapper.Map<List<SiteConfigDto>>(commentlist);
        }

        public int Updata(SiteConfigDto dto)
        {
            var siteconfig = _mapper.Map<SiteConfig>(dto);
            var newsiteconfigt = _siteconfigRep.GetModel(siteconfig.Id);
            newsiteconfigt.UpDate(siteconfig);
            _siteconfigRep.Update(newsiteconfigt);
            return _unitOfWork.SaveChange();
        }
    }
}
