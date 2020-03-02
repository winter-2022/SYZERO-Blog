using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;
using SyZeroBlog.Core.Configuration;

namespace SyZeroBlog.EntityFrameworkCore
{
    //这个类需要在开发时从命令行运行“dotnet ef…”命令
    public class SyZeroBlogDbContextFactory : IDesignTimeDbContextFactory<SyZeroBlogDbContext>
    {
        public SyZeroBlogDbContext CreateDbContext(string[] args)
        {
            var configuration = AppConfigurations.Configuration;
            var builder = new DbContextOptionsBuilder<SyZeroBlogDbContext>();
            var connectionString = configuration.GetConnectionString("sqlConnection");
            if (configuration.GetConnectionString("type").ToLower() == "mysql")
                builder.UseMySql(connectionString);
            else
                builder.UseSqlServer(connectionString);
            return new SyZeroBlogDbContext(builder.Options);
        }
    }
}
