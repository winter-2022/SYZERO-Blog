using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SyZero.Domain.Repository;
using SyZero.Domain.Service;
using SyZeroBlog.Core.Authorization.Users;

namespace SyZeroBlog.Core.Authorization
{
    public class RegistrationManager: DomainService
    {
        private IRepository<User> _userRepository;
        private UserManager _userManager;
        public RegistrationManager(IRepository<User> userRepository, UserManager userManager)
        {
            _userRepository = userRepository;
            _userManager = userManager;
        }
        public async Task<User> RegisterAsync(string username, string password, string phone)
        {
            if (await _userRepository.GetModelAsync(p => p.Name == username) != null)
            {
                throw new Exception("用户名重复");
            }
            var user = new User()
            {
                Name = username,
                Password = password,
                Phone = phone,
                Sex = 1,
                 LastIP="ssss",
                  LastTime=DateTime.Now,
                   Level =1,
                    Mail="",
                     PictureId=2123131,
                      Status=1,
                       Type=1
            };

            return await _userManager.CreateAsync(user);
        }
    }
}
