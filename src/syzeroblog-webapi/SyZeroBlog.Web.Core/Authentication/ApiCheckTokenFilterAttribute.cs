using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

using SyZeroBlog.Core.Configuration;
using SyZeroBlog.Web.Core.Models;
using SyZero.Domain.Repository;
using SyZeroBlog.Core.Authorization.Users;
using SyZero.Cache;
using SyZero;

namespace SyZeroBlog.Web.Core.Authentication
{


    /// <summary>
    /// Action 拦截验证授权码
    /// </summary>
    public class ApiCheckTokenFilterAttribute : ActionFilterAttribute
    {
     
        /// <summary>
        /// 忽略本特性
        /// </summary>
        public bool Ignore { get; set; } = false;

        /// <summary>
        /// 每次请求Action之前发生，，在行为方法执行前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            base.OnActionExecuting(context);

            if (Ignore) return;

            //验证是否存在Token
            if (!context.HttpContext.Request.Headers.ContainsKey("Authorization"))
                throw new MessageBox(new { code = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

            ////得到Controller对象
            var _Controller = context.Controller as SyZeroBlog.Web.Core.Controllers.BaseApiController;
            if (_Controller == null)
                throw new MessageBox(new { code = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

            if (_Controller.User == null)
                throw new MessageBox(new { code = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

        }

        public ClaimsPrincipal GetPrincipal(string token)
        { // 此方法用解码字符串token，并返回秘钥的信息对象
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
