using Panda.DynamicWebApi;
using Panda.DynamicWebApi.Attributes;
using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Application.Service;

namespace SyZeroBlog.Application
{
    [DynamicWebApi]
    public  interface IApplicationServiceBase : IApplicationService, IDynamicWebApi
    {
    }
}
