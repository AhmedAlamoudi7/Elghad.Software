using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class EditImageTabUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<byte[]>(
                name: "ProfileImgUser",
                table: "AspNetUsers",
                type: "varbinary(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ProfileImgUser",
                table: "AspNetUsers");

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
