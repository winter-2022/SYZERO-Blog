using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SyZero.Application.Dto;

namespace LiliBuyMasterService.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    public class UserController : Controller
    {

        public IConfiguration Configuration { get; }

        public UserController(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        [HttpPost("Login")]
        public string Login([FromQuery]LoginDto request)
        {
            if (request != null)
            {
                //验证账号密码,这里只是为了demo，正式场景应该是与DB之类的数据源比对
                if ("123456".Equals(request.UserName) && "123456".Equals(request.Password))
                {
                    var claims = new[] {
                        //加入用户的名称
                        new Claim(ClaimTypes.Name,request.UserName)
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]));
                    var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                    var authTime = DateTime.UtcNow;
                    var expiresAt = authTime.AddDays(7);

                    var token = new JwtSecurityToken(
                        issuer: "syzero.com",
                        audience: "syzero.com",
                        claims: claims,
                        expires: expiresAt,
                        signingCredentials: creds);
                    string usertoken = new JwtSecurityTokenHandler().WriteToken(token);
                    return usertoken;
                }
            }
            return "账号或密码错误";
        }
    }
}