using Microsoft.EntityFrameworkCore.Migrations;

namespace SyZeroBlog.EntityFrameworkCore.Migrations
{
    public partial class _12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Template",
                table: "Blog",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Template",
                table: "Blog");
        }
    }
}
