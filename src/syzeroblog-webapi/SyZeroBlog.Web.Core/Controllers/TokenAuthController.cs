using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SyZeroBlog.Application.Users.Dto;
using SyZeroBlog.Core.Configuration;
using SyZeroBlog.Web.Core.Models;
using SyZeroBlog.Core.Authorization;
using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Application.Authorization.Accounts.Dto;
using SyZeroBlog.Application.Authorization.Accounts;
using SyZero.ObjectMapper;
using SyZero.AutoMapper;
using SyZero.Cache;
using SyZero.Logger;
using SyZero.Web.Common;
using SyZeroBlog.Web.Core.Authentication;
using SyZero.Runtime.Security;
using SyZero.Runtime.Session;

namespace SyZeroBlog.Web.Core.Controllers
{
    [Route("api/[controller]/[action]")]
    public class TokenAuthController : BaseApiController
    {
        private LoginManager _loginManager;
        private AccountService _accountService;
        private readonly ISyEncode _syEncode;

        public TokenAuthController(LoginManager loginManager, AccountService accountService, ISyEncode syEncode)
        {
            _loginManager = loginManager;
            _accountService = accountService;
            _syEncode = syEncode;
        }

        /// <summary>
        /// 管理登录接口 获取Token
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<object> Authenticate([FromBody]LoginDto login)
        {
            Logger.Info("用户登录：" + login.username);
            var user = await _loginManager.loginResult(login.username, _syEncode.Get32MD5One(login.password));
            if (user==null)
            {
                throw new MessageBox("密码或账号不正确！");
            }
            if (user.Level != 1)
            {
                throw new MessageBox("请使用管理员账号登录！");
            }
            var claims = new[] {
                            new Claim(SyClaimTypes.UserName,login.username),
                            new Claim(SyClaimTypes.UserId,user.Id.ToString())
                        };
            
            var accessToken = await Task.Run(() => CreateAccessToken(claims));

            Cache.Set(user.Id.ToString(), accessToken);
            return new { token=accessToken, uuid = user.Id, name = user.Name };
        }


        /// <summary>
        /// 退出登录
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        [ApiCheckTokenFilter]
        public async Task<bool> LogOut()
        {
            await Cache.RemoveAsync(SySession.UserId.ToString());
            return true;
        }


        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="claims"></param>
        /// <returns></returns>
        private string CreateAccessToken(IEnumerable<Claim> claims)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfigurations.GetSection("JWT:SecurityKey")));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
            var authTime = DateTime.UtcNow;
            var expiresAt = authTime.AddDays(int.Parse(AppConfigurations.GetSection("JWT:expires")));
            var token = new JwtSecurityToken(
                issuer: AppConfigurations.GetSection("JWT:issuer"),
                audience: AppConfigurations.GetSection("JWT:audience"),
                claims: claims,
                expires: expiresAt,
                signingCredentials: creds);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }



    }
}
