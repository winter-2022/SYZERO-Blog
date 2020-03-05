using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using SyZero.EntityFrameworkCore;
using SyZeroBlog.Core.Authorization.Users;
using SyZeroBlog.Core.BlogManagement;
using SyZeroBlog.Core.BlogManagement.Blogs;
using SyZeroBlog.Core.BlogManagement.Categorys;
using SyZeroBlog.Core.BlogManagement.Comments;
using SyZeroBlog.Core.BlogManagement.Tags;
using SyZeroBlog.Core.Files;
using SyZeroBlog.Core.Links;
using SyZeroBlog.Core.Navigations;

namespace SyZeroBlog.EntityFrameworkCore
{
    public class SyZeroBlogDbContext : SyZeroDbContext<User,SyZeroBlogDbContext>
    {
        public SyZeroBlogDbContext()
        {
        }

        public SyZeroBlogDbContext(DbContextOptions<SyZeroBlogDbContext> options) : base(options)
        {

        }
        public DbSet<File> File { get; set; }
        public DbSet<BlogCategory> BlogCategory { get; set; }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<Tag> Tag { get; set; }
        public DbSet<Comment>  Comment { get; set; }
        public DbSet<Navigation> Navigation { get; set; }
        public DbSet<Link> Link { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>()
                .HasOne(a => a.HeadPicture)
                .WithOne(b => b.CreateUser)
                .HasForeignKey<File>(b => b.CreateUserId);

            modelBuilder.Entity<BlogCategory>()
                 .HasMany(t => t.Childs)
                 .WithOne(t => t.Parent)
                 .HasForeignKey(t => t.ParentId);

            modelBuilder.Entity<BlogCategory>()
                .HasMany(g => g.Blogs)
                .WithOne(s => s.Category)
                .HasForeignKey(s => s.CategoryId);

            //多对多
            modelBuilder.Entity<BlogTag>()
                .HasKey(t => new { t.BlogId, t.TagId });
            modelBuilder.Entity<Blog>()
                .HasMany(g => g.BlogTags)
                .WithOne(s => s.Blog)
                .HasForeignKey(s => s.BlogId);
            modelBuilder.Entity<Tag>()
                .HasMany(g => g.BlogTags)
                .WithOne(s => s.Tag)
                .HasForeignKey(s => s.TagId);

            modelBuilder.Entity<Comment>()
                .HasMany(g => g.Childs)
                .WithOne(t => t.Parent)
                .HasForeignKey(t => t.ParentId);

            modelBuilder.Entity<Blog>()
                .HasMany(g => g.Comments)
                .WithOne(t => t.Blog)
                .HasForeignKey(t => t.BlogId);

            modelBuilder.Entity<Navigation>()
                .HasMany(g => g.Childs)
                .WithOne(t => t.Parent)
                .HasForeignKey(t => t.ParentId);
        }
    }
}
