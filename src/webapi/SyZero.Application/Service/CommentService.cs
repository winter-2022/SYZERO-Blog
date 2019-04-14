using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SyZero.Domain.Repository;
using SyZero.Domain.Model;


namespace SyZero.Application
{
    public class CommentService : ICommentService
    {
        private readonly IRepository<Comment> _commentRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CommentService(IRepository<Comment> commentRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _commentRep = commentRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public bool Add(CommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            _commentRep.Add(comment);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _commentRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public CommentDto GetDto(string Id)
        {
            var article = _commentRep.GetModel(Id);
            return _mapper.Map<CommentDto>(article);
        }

        public List<CommentDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var commentlist = _commentRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p => p.Id, u => u.Content.IndexOf(queryDto.key) > 0, false);
            return _mapper.Map<List<CommentDto>>(commentlist);
        }

        public int Updata(CommentDto dto)
        {
            var comment = _mapper.Map<Comment>(dto);
            var newcomment = _commentRep.GetModel(comment.Id);
            newcomment.UpDate(comment);
            _commentRep.Update(newcomment);
            return _unitOfWork.SaveChange();
        }
    }
}
