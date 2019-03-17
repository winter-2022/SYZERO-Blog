using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SyZero.Infrastructure.EntityFramework.Migrations
{
    public partial class SYZERO21 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(maxLength: 200, nullable: true),
                    TypeCode = table.Column<string>(nullable: true),
                    Category = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true),
                    Author = table.Column<string>(nullable: true),
                    ClickCount = table.Column<int>(nullable: false),
                    FabulousCount = table.Column<int>(nullable: false),
                    ShareCount = table.Column<int>(nullable: false),
                    ScoreCount = table.Column<int>(nullable: false),
                    SEOTitle = table.Column<string>(nullable: true),
                    SEOKeywords = table.Column<string>(nullable: true),
                    SEODescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ArticleCategory",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    TypeCode = table.Column<string>(nullable: true),
                    ParentID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(maxLength: 1000, nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    Tags = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleCategory", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Comment",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: false),
                    ArticleID = table.Column<long>(nullable: false),
                    ParentID = table.Column<long>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false),
                    FabulousCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comment", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Message",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    UserID = table.Column<long>(nullable: false),
                    TypeCode = table.Column<string>(nullable: true),
                    ParentID = table.Column<long>(nullable: false),
                    Messages = table.Column<string>(nullable: true),
                    Content = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Message", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SiteConfig",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Key = table.Column<string>(nullable: true),
                    Value = table.Column<string>(nullable: true),
                    ParentID = table.Column<long>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Picture = table.Column<string>(nullable: true),
                    AddTime = table.Column<DateTime>(nullable: false),
                    UpdateTime = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SiteConfig", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(maxLength: 200, nullable: true),
                    Password = table.Column<string>(maxLength: 200, nullable: true),
                    Mail = table.Column<string>(maxLength: 200, nullable: true),
                    Phone = table.Column<string>(maxLength: 200, nullable: true),
                    Photo = table.Column<string>(maxLength: 1000, nullable: true),
                    Utype = table.Column<int>(nullable: false),
                    Sex = table.Column<int>(nullable: false),
                    AddTime = table.Column<DateTime>(nullable: false),
                    LastTime = table.Column<DateTime>(nullable: false),
                    State = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.DropTable(
                name: "ArticleCategory");

            migrationBuilder.DropTable(
                name: "Comment");

            migrationBuilder.DropTable(
                name: "Message");

            migrationBuilder.DropTable(
                name: "SiteConfig");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
