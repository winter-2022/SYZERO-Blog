using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SyZero.Domain.Model;
namespace SyZero.Infrastructure.EfRepository
{
    public class SyDbContext : DbContext
    {
        public SyDbContext()
        {
        }

        public SyDbContext(DbContextOptions<SyDbContext> options) : base(options)
        {

        }
        public DbSet<User> User { get; set; }
        public DbSet<Article> Article { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Comment> Comment { get; set; }
        public DbSet<Config> Message { get; set; }
        public DbSet<File> SiteConfig { get; set; }
        public DbSet<Modular> Modular { get; set; }
        public DbSet<Navigation> Navigation { get; set; }
        public DbSet<Page> Page { get; set; }
        public DbSet<Tag> Tag { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // modelBuilder.Entity<ArticleEntity>().HasIndex(u => u.Id).IsUnique();
        }
    }
}
