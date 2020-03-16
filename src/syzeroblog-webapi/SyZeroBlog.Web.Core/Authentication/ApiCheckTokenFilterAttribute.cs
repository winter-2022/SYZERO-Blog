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
using SyZero.Runtime.Entities;

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

            if (context.HttpContext.User == null)
                throw new SyMessageBox(new { code = SyMessageBoxStatus.接口授权码无效.ToInt32(), msg = $"{SyMessageBoxStatus.接口授权码无效.ToString()}" });

        }


       

    }

 



}
