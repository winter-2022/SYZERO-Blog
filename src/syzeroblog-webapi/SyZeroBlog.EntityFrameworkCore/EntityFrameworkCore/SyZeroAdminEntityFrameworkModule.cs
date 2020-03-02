using Autofac;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using SyZero.Domain.Repository;
using SyZero.EntityFrameworkCore;
using SyZero.EntityFrameworkCore.Repositories;
using SyZeroBlog.EntityFrameworkCore.Repositories;

namespace SyZeroBlog.EntityFrameworkCore
{
    public class SyZeroBlogEntityFrameworkModule : Module
    {
       private IConfiguration _configuration;
       public SyZeroBlogEntityFrameworkModule(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            
            // 首先注册 options，供 DbContext 服务初始化使用
          builder.AddSyZeroEntityFramework<SyZeroBlogDbContext>(_configuration);
            //注册仓储泛型
          builder.RegisterGeneric(typeof(SyZeroBlogRepositoryBase<>)).As(typeof(IRepository<>)).InstancePerDependency().PropertiesAutowired();
            ////注册持久化
          builder.RegisterType<UnitOfWork<SyZeroBlogDbContext>>().As<IUnitOfWork>().PropertiesAutowired();
        }
    }
}
