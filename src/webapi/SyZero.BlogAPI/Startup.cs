using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.Swagger;
using SyZero.Infrastructure.EntityFramework;
using SyZero.Domain.Interface;
using SyZero.Domain.Model;
using SyZero.Infrastructure.EfRepository;
using SyZero.Infrastructure.Mongo;
using SyZero.Infrastructure.MongoRepository;
using System.Reflection;
using SyZero.Application;
using SyZero.Domain.DomainService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace SyZero.BlogAPI
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        public IContainer ApplicationContainer { get; private set; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,//是否验证Issuer
                        ValidateAudience = true,//是否验证Audience
                        ValidateLifetime = true,//是否验证失效时间
                        ValidateIssuerSigningKey = true,//是否验证SecurityKey
                        ValidAudience = "syzero.com",//Audience
                        ValidIssuer = "syzero.com",//Issuer，这两项和前面签发jwt的设置一致
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))//拿到SecurityKey
                    };
                });


            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            #region Swagger
            services.AddSwaggerGen(c =>
              {
                  c.SwaggerDoc("v1", new Info
                  {
                      Version = "v1",
                      Title = "SyBlog接口文档",
                      Description = "RESTful API for SyBlogManagement",
                      TermsOfService = "None",
                      Contact = new Contact { Name = "SYZERO", Email = "522112669@qq.com", Url = "http://syzero.com" }
                  });

                  c.OperationFilter<AuthTokenHeaderParameter>();
                  var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);//获取应用程序所在目录（绝对，不受工作目录影响，建议采用此方法获取路径）PlatformServices.Default.Application.ApplicationBasePath;
                  var xmlPath = Path.Combine(basePath, "syBlogApi.xml");
                  c.IncludeXmlComments(xmlPath);
                  //  c.OperationFilter<HttpHeaderOperation>(); // 添加httpHeader参数
              });
            #endregion

            //使用Mongo连接数据库
            //services.UseMongoDB(Configuration.GetSection("MongoConnection"));
            //services.AddTransient(typeof(IUnitOfWork), typeof(UnitOfWork));   //注册数据持久
            //使用EF连接数据库
            services.UseEntityFramework(Configuration.GetConnectionString("sqlConnection"));

            //services.AddMvc(options =>
            //{
            //    options.Filters.Add(typeof(WebApiResultMiddleware));
            //    options.RespectBrowserAcceptHeader = true;
            //});

            var builder = new ContainerBuilder();//实例化 AutoFac  容器            
            builder.Populate(services);
            builder.RegisterGeneric(typeof(EfRepository<>)).As(typeof(IEfRepository<>)).InstancePerDependency();//注册仓储泛型
            builder.RegisterGeneric(typeof(MongoRepository<>)).As(typeof(IMongoRepository<>)).InstancePerDependency();//注册仓储泛型

            #region 注入Application和DomainService
            var assemblys1 = Assembly.Load("SyZero.Application");//Service是继承接口的实现方法类库名称
            var baseType1 = typeof(IBaseService<>);//IBaseService 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys1)
                .Where(m => baseType1.IsAssignableFrom(m) && m != baseType1)
                .AsImplementedInterfaces().InstancePerLifetimeScope();

            var assemblys = Assembly.Load("SyZero.Domain.DomainService");//Service是继承接口的实现方法类库名称
            var baseType = typeof(IDependency);//IDependency 是一个接口（所有要实现依赖注入的借口都要继承该接口）
            builder.RegisterAssemblyTypes(assemblys)
                .Where(m => baseType.IsAssignableFrom(m) && m != baseType)
                .AsImplementedInterfaces().InstancePerLifetimeScope();
            #endregion

            ApplicationContainer = builder.Build();
            return new AutofacServiceProvider(ApplicationContainer);//第三方IOC接管 core内置DI容器
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseAuthentication();

            app.UseHttpsRedirection();

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();

            // Enable middleware to serve swagger-ui (HTML, JS, CSS etc.), specifying the Swagger JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SyBlogManagement API V1");
                c.RoutePrefix = string.Empty;
            });

            //cors跨域
            app.UseCors(builder =>
            {
                builder.AllowAnyOrigin() //允许任何来源的主机访问
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials();//指定处理cookie
            });


            app.UseMvc();
        }
    }
}
