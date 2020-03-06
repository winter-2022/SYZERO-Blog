using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

using SyZeroBlog.Core.Configuration;
using SyZeroBlog.Web.Core.Models;
using SyZero.Domain.Repository;
using SyZeroBlog.Core.Authorization.Users;
using SyZero.Cache;
using SyZero;
using SyZero.Runtime.Security;

namespace SyZeroBlog.Web.Core.Authentication
{


    /// <summary>
    /// Action 拦截验证授权码
    /// </summary>
    public class ApiCheckTokenFilterAttribute : ActionFilterAttribute ,IOrderedFilter
    {
        public new int Order => 2;
        /// <summary>
        /// 每次请求Action之前发生，，在行为方法执行前执行
        /// </summary>
        /// <param name="context"></param>
        public override void OnActionExecuting(ActionExecutingContext context)
        {

            ////得到Controller对象
            var _Controller = context.Controller as SyZeroBlog.Web.Core.Controllers.BaseApiController;


            var tenantIdClaim = _Controller.User?.Claims.FirstOrDefault(c => c.Type == SyClaimTypes.UserId);
            if (string.IsNullOrEmpty(tenantIdClaim?.Value))
                throw new MessageBox(new { code = EMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{EMessageBoxStatus.接口授权码无效.ToString()}" });

        }


       

    }

 



}
