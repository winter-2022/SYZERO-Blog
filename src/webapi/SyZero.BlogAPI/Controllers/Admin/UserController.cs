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

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SyZero.BlogAPI.Controllers.Admin
{
    [AllowAnonymous]
    [Route("api/a/[controller]")]
    public class UserController : BaseController
    {
        public IConfiguration _configuration { get; }

        public UserController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [HttpPost("Login")]
        public ResultJson Login([FromQuery]LoginDto request)
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

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:SecurityKey"]));
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
                    return ResultJson("登陆成功", usertoken);
                }
            }
            return ResultJson("账号或密码错误", null, 401);
        }

       

        // POST api/<controller>
        [HttpPost]
        public void Post([FromBody]string value)
        {
        }

        // PUT api/<controller>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody]string value)
        {
        }

       
    }
}
