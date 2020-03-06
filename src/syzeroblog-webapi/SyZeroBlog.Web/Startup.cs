using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Autofac.Extensions.DependencyInjection;
using AutoMapper;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using SyZero;
using SyZero.AspNetCore;
using SyZero.AutoMapper;
using SyZero.Domain.Repository;
using SyZero.DynamicWebApi;
using SyZero.Log4Net;
using SyZero.Redis;
using SyZero.Web.Common;
using SyZeroBlog.EntityFrameworkCore;
using SyZeroBlog.EntityFrameworkCore.Repositories;
using SyZeroBlog.Web.Core.Controllers;

namespace SyZeroBlog.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        /// <summary>
        /// 原生Ioc注入
        /// </summary>
        /// <param name="services"></param>
        /// <returns></returns>
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
                      ValidAudience = Configuration["JWT:audience"],//Audience
                      ValidIssuer = Configuration["JWT:issuer"],//Issuer，这两项和前面签发jwt的设置一致
                      IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["JWT:SecurityKey"]))//拿到SecurityKey
                  };
            });
            services.Replace(ServiceDescriptor.Transient<IControllerActivator, ServiceBasedControllerActivator>());

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1).AddMvcOptions(options =>
            {
                options.Filters.Add(new SyZeroBlog.Web.Core.Authentication.AppVerificationFilter());
                options.Filters.Add(new SyZeroBlog.Web.Core.Authentication.AppExceptionFilter());
                options.Filters.Add(new SyZeroBlog.Web.Core.Authentication.AppResultFilter());
            }).AddJsonOptions(options =>
                {
                    options.SerializerSettings.Converters.Add(new LongToStrConverter());
                }
            );
            //动态WebApi
            services.AddDynamicWebApi();
            services.AddCors(options =>
                {
                    options.AddPolicy("any", builder =>
                    {
                        builder.AllowAnyOrigin() //允许任何来源的主机访问
                            .AllowAnyMethod()
                            .AllowAnyHeader()
                            .AllowCredentials();//指定处理cookie

                    });
                }
            );
            #region Swagger
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "SyZeroBlog接口文档",
                    Description = "RESTful API for SyZeroBlog",
                    Contact = new OpenApiContact() { Name = "SYZERO", Email = "522112669@qq.com", Url = new Uri("http://test6.syzero.com") }
                });
                options.DocInclusionPredicate((docName, description) => true);
                // Define the BearerAuth scheme that's in use
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Description = "在下框中输入请求头中需要添加Jwt授权Token：Bearer Token",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] { }
                    }
                });
                var basePath = Path.GetDirectoryName(typeof(Program).Assembly.Location);
                var xmlPath = Path.Combine(basePath, "SyZeroBlog.Web.xml");
                options.IncludeXmlComments(xmlPath);
            });
            #endregion

            return services.AddSyZeroAutofac(AutofacServices);
        }

        /// <summary>
        /// Autofac注入模块
        /// </summary>
        /// <param name="builder"></param>
        public void AutofacServices(ContainerBuilder builder) {

            //使用AutoMapper
            builder.RegisterModule(new AutoMapperModule());
            //使用EF仓储
            builder.RegisterModule(new SyZeroBlogEntityFrameworkModule(Configuration));
            //使用SyZero
            builder.RegisterModule(new SyZeroModule());
            //注入控制器
            builder.RegisterModule(new SyZeroControllerModule());
            //注入Log4Net
            builder.RegisterModule(new Log4NetModule());
            //注入Redis
            builder.RegisterModule(new RedisModule(Configuration));
            //注入公共层
            builder.RegisterModule(new CommonModule());
        }


        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseCors("any");
         
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "defaultWithArea",
                    template: "{area}/{controller=Home}/{action=Index}/{id?}");

                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "SyBlogManagement API V1");
                c.RoutePrefix = string.Empty;

            });

        }
    }
}
