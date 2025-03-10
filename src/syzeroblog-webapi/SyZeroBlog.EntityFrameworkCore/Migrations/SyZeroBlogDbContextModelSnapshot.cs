﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using SyZeroBlog.EntityFrameworkCore;

namespace SyZeroBlog.EntityFrameworkCore.Migrations
{
    [DbContext(typeof(SyZeroBlogDbContext))]
    partial class SyZeroBlogDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.14-servicing-32113")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("SyZero.Domain.Entities.Config", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Name");

                    b.Property<string>("Value");

                    b.HasKey("Id");

                    b.ToTable("Config");
                });

            modelBuilder.Entity("SyZeroBlog.Core.Authorization.Users.User", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("AddTime");

                    b.Property<string>("LastIP");

                    b.Property<DateTime?>("LastTime");

                    b.Property<int>("Level");

                    b.Property<string>("Mail");

                    b.Property<string>("Name");

                    b.Property<string>("NickName");

                    b.Property<string>("Password");

                    b.Property<string>("Phone");

                    b.Property<long>("PictureId");

                    b.Property<int>("Sex");

                    b.Property<int>("Status");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.ToTable("User");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Blogs.Blog", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Alias");

                    b.Property<long?>("CategoryId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<long?>("CreateUserId");

                    b.Property<string>("Describe");

                    b.Property<bool>("IsTop");

                    b.Property<int>("LikeNums");

                    b.Property<int>("Order");

                    b.Property<int>("Status");

                    b.Property<string>("Template");

                    b.Property<string>("Title");

                    b.Property<string>("Type");

                    b.Property<int>("ViewNums");

                    b.HasKey("Id");

                    b.HasIndex("CategoryId");

                    b.HasIndex("CreateUserId");

                    b.ToTable("Blog");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.BlogTag", b =>
                {
                    b.Property<long>("BlogId");

                    b.Property<long>("TagId");

                    b.HasKey("BlogId", "TagId");

                    b.HasIndex("TagId");

                    b.ToTable("BlogTag");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Categorys.BlogCategory", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Alias");

                    b.Property<string>("Describe");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<int>("Order");

                    b.Property<long?>("ParentId");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("BlogCategory");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Comments.Comment", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Author");

                    b.Property<long>("BlogId");

                    b.Property<string>("Content");

                    b.Property<DateTime>("CreateTime");

                    b.Property<string>("Email");

                    b.Property<string>("Ip");

                    b.Property<long?>("ParentId");

                    b.Property<int>("Status");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("BlogId");

                    b.HasIndex("ParentId");

                    b.ToTable("Comment");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Tags.Tag", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Alias");

                    b.Property<string>("Describe");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.HasKey("Id");

                    b.ToTable("Tag");
                });

            modelBuilder.Entity("SyZeroBlog.Core.Files.File", b =>
                {
                    b.Property<long>("Id");

                    b.Property<DateTime>("CreateTime");

                    b.Property<long>("CreateUserId");

                    b.Property<string>("From");

                    b.Property<string>("Name");

                    b.Property<int>("Size");

                    b.Property<string>("SourceName");

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.HasIndex("CreateUserId")
                        .IsUnique();

                    b.ToTable("File");
                });

            modelBuilder.Entity("SyZeroBlog.Core.Links.Link", b =>
                {
                    b.Property<long>("Id");

                    b.Property<string>("Description");

                    b.Property<bool>("IsHide");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.ToTable("Link");
                });

            modelBuilder.Entity("SyZeroBlog.Core.Navigations.Navigation", b =>
                {
                    b.Property<long>("Id");

                    b.Property<bool>("IsHide");

                    b.Property<bool>("IsNewTab");

                    b.Property<string>("Name");

                    b.Property<int>("Order");

                    b.Property<long?>("ParentId");

                    b.Property<string>("Url");

                    b.HasKey("Id");

                    b.HasIndex("ParentId");

                    b.ToTable("Navigation");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Blogs.Blog", b =>
                {
                    b.HasOne("SyZeroBlog.Core.BlogManagement.Categorys.BlogCategory", "Category")
                        .WithMany("Blogs")
                        .HasForeignKey("CategoryId");

                    b.HasOne("SyZeroBlog.Core.Authorization.Users.User", "CreateUser")
                        .WithMany()
                        .HasForeignKey("CreateUserId");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.BlogTag", b =>
                {
                    b.HasOne("SyZeroBlog.Core.BlogManagement.Blogs.Blog", "Blog")
                        .WithMany("BlogTags")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SyZeroBlog.Core.BlogManagement.Tags.Tag", "Tag")
                        .WithMany("BlogTags")
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Categorys.BlogCategory", b =>
                {
                    b.HasOne("SyZeroBlog.Core.BlogManagement.Categorys.BlogCategory", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("SyZeroBlog.Core.BlogManagement.Comments.Comment", b =>
                {
                    b.HasOne("SyZeroBlog.Core.BlogManagement.Blogs.Blog", "Blog")
                        .WithMany("Comments")
                        .HasForeignKey("BlogId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("SyZeroBlog.Core.BlogManagement.Comments.Comment", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });

            modelBuilder.Entity("SyZeroBlog.Core.Files.File", b =>
                {
                    b.HasOne("SyZeroBlog.Core.Authorization.Users.User", "CreateUser")
                        .WithOne("HeadPicture")
                        .HasForeignKey("SyZeroBlog.Core.Files.File", "CreateUserId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("SyZeroBlog.Core.Navigations.Navigation", b =>
                {
                    b.HasOne("SyZeroBlog.Core.Navigations.Navigation", "Parent")
                        .WithMany("Childs")
                        .HasForeignKey("ParentId");
                });
#pragma warning restore 612, 618
        }
    }
}
