using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.Configuration;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using SyZero;
using SyZero.AspNetCore.Controllers;
using SyZero.Cache;
using SyZero.Domain.Repository;

using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Core.Configuration;

namespace SyZeroBlog.Web.Core.Controllers
{
    public class BaseApiController : SyZeroController
    {
        public IRepository<User> _userRepository { get; set; }
 
        /// <summary>
        /// 用户信息
        /// </summary>
        public new User User
        {
            get
            {
                var claims = GetPrincipal(Token);
                if (claims == null)
                {
                    return null;
                }
                var cacheToken = Cache.Get<string>(claims.FindFirst("id").Value, out bool isExisted);
                if (!isExisted || cacheToken != Token)
                {
                    return null;
                }
                var user = _userRepository.GetModel(claims.FindFirst("id").Value.ToLong());
                return user;
            }
            set { }
        }
        /// <summary>
        /// 登录Token
        /// </summary>
        public string Token
        {
            get
            {
                if (!Request.Headers.ContainsKey("Authorization"))
                {
                    return null;
                }
                else
                {
                    return Request.Headers["Authorization"];
                 
                }
            }
            set
            {
               
            }
        }


        /// <summary>
        /// 此方法用解码字符串token，并返回秘钥的信息对象
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        protected ClaimsPrincipal GetPrincipal(string token)
        { 
            try
            {
                var tokenHandler = new JwtSecurityTokenHandler(); // 创建一个JwtSecurityTokenHandler类，用来后续操作
                var jwtToken = tokenHandler.ReadToken(token) as JwtSecurityToken; // 将字符串token解码成token对象
                if (jwtToken == null)
                    return null;

                var validationParameters = new TokenValidationParameters() // 生成验证token的参数
                {
                    ValidateIssuer = true,//是否验证Issuer
                    ValidateAudience = true,//是否验证Audience
                    ValidateLifetime = true,//是否验证失效时间
                    ValidateIssuerSigningKey = true,//是否验证SecurityKey
                    ValidAudience = AppConfigurations.GetSection("JWT:audience"),//Audience
                    ValidIssuer = AppConfigurations.GetSection("JWT:issuer"),//Issuer，这两项和前面签发jwt的设置一致
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(AppConfigurations.GetSection("JWT:SecurityKey")))//拿到SecurityKey
                };
                SecurityToken securityToken; // 接受解码后的token对象

                return tokenHandler.ValidateToken(token, validationParameters, out securityToken);
            }

            catch (Exception ex)
            {
                return null;
            }
        }

    }
}
