using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SyZero.Domain.Model;
namespace SyZero.Infrastructure.EntityFramework
{
    public class SyDbContext:DbContext
    {
        public SyDbContext()
        {
        }

        public SyDbContext(DbContextOptions<SyDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<ArticleCategory> ArticleCategory { get; set; }
        public DbSet<Comment>  Comment { get; set; }
        public DbSet<Message>  Message { get; set; }
        public DbSet<SiteConfig>  SiteConfig { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
           // modelBuilder.Entity<ArticleEntity>().HasIndex(u => u.Id).IsUnique();
        }
    }
}
