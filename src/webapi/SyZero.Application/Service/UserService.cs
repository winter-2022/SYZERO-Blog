using AutoMapper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Dto;
using SyZero.Application.Interface;
using SyZero.Common;
using SyZero.Domain;
using SyZero.Domain.Interface;
using SyZero.Domain.Model;


namespace SyZero.Application.Service
{
    class UserService : IUserService
    {
        private readonly IEfRepository<User> _userRep;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UserService(IEfRepository<User> userRep, IMapper mapper, IUnitOfWork unitOfWork)
        {
            _userRep = userRep;
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public bool Add(UserDto dto)
        {
            var user = _mapper.Map<User>(dto).AddUser();
            return _unitOfWork.SaveChange() > 0;
        }

        public bool Delect(string IDs)
        {
            string[] arry = IDs.Split(',');
            _userRep.Delete(u => ((IList)arry).Contains(u.Id.ToString()));
            return _unitOfWork.SaveChange() > 0;
        }

        public UserDto GetDto(string Id)
        {
            var user = _userRep.GetModel(long.Parse(Id));
            return _mapper.Map<UserDto>(user);
        }

        public List<UserDto> GetList(QueryDto queryDto)
        {
            queryDto.offset = string.IsNullOrEmpty(queryDto.offset) ? "0" : queryDto.offset;
            queryDto.limit = string.IsNullOrEmpty(queryDto.limit) ? "20" : queryDto.limit;
            var userlist = _userRep.GetPaged(int.Parse(queryDto.offset), int.Parse(queryDto.limit), p=>p.Id,u=>u.Name.IndexOf(queryDto.key) > 0,false);
            return _mapper.Map<List<UserDto>>(userlist);
        }

        public bool IsRepeatByName(string UserName)
        {
            bool IsExist = _userRep.Count(u => u.Name == UserName) > 0;
            return IsExist;
        }

        public bool Login(string UserName, string Password)
        {
            bool IsExist = _userRep.Count(u => u.Name == UserName && u.Password == MD5Comm.Get32MD5One(Password)) > 0;
            return IsExist;
        }

        public int Register(RegisterDto registerDto)
        {
            var user = new User(registerDto.name, MD5Comm.Get32MD5One(registerDto.password), registerDto.sex,
                registerDto.mail, registerDto.phone);
            _userRep.Add(user);
            return _unitOfWork.SaveChange();
        }

        public int Updata(UserDto dto)
        {
            var user = _mapper.Map<User>(dto);
            var newuser = _userRep.GetModel(user.Id);
            newuser.UpDateInfo(user);
            _userRep.Update(newuser);
            return _unitOfWork.SaveChange();
        }

        public int UpdataInfo(UserDto  userDto)
        {
            var user = _mapper.Map<User>(userDto);
            var newuser = _userRep.GetModel(user.Id);
            newuser.UpDateInfo(user);
            _userRep.Update(newuser);
            return _unitOfWork.SaveChange();
        }
    }
}
