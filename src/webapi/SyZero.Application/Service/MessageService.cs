using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

using SyZero.Domain.Repository;
using SyZero.Domain.Model;

namespace SyZero.Application
{
    public class MessageService : IMessageService
    {
        private readonly IRepository<Message> _messageRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public MessageService(IRepository<Message> messageRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _messageRep = messageRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool Add(MessageDto dto)
        {
           var messgae =  _mapper.Map<Message>(dto);
            _messageRep.Add(messgae);
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _messageRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public MessageDto GetDto(string Id)
        {
            var message = _messageRep.GetModel(Id);
            return _mapper.Map<MessageDto>(message);
        }

        public List<MessageDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var messagelist = _messageRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p => p.Id, u => u.Messages.IndexOf(queryDto.key) > 0, false);
            return _mapper.Map<List<MessageDto>>(messagelist);
        }

        public int Updata(MessageDto dto)
        {
            var message = _mapper.Map<Message>(dto);
            var newmessage = _messageRep.GetModel(message.Id);
            newmessage.UpDate(message);
            _messageRep.Update(newmessage);
            return _unitOfWork.SaveChange();
        }
    }
}
