using System;
using System.Collections.Generic;
using System.Text;
using SyZeroBlog.Core.Authorization.Users;
using SyZero.Domain.Repository;
using System.Threading.Tasks;
using SyZero.Domain.Service;

namespace SyZeroBlog.Core.Authorization
{
    public class LoginManager: DomainService
    {
        private IRepository<User> _userRepository;
        public LoginManager(IRepository<User> userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<User> loginResult(string username,string password)
        {

            var user = await _userRepository.GetModelAsync(p => p.Name == username && p.Password == password);
            return user;
        }
    }
}
