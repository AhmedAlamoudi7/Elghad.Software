using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class EditAllTabToAddBaseEntity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "orgnization",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "orgnization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "orgnization",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "orgnization",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "orgnization",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "CreateAt",
                table: "HiringOrder",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "CreateBy",
                table: "HiringOrder",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HiringOrder",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateAt",
                table: "HiringOrder",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UpdateBy",
                table: "HiringOrder",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "orgnization");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "orgnization");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "orgnization");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "orgnization");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "orgnization");

            migrationBuilder.DropColumn(
                name: "CreateAt",
                table: "HiringOrder");

            migrationBuilder.DropColumn(
                name: "CreateBy",
                table: "HiringOrder");

            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HiringOrder");

            migrationBuilder.DropColumn(
                name: "UpdateAt",
                table: "HiringOrder");

            migrationBuilder.DropColumn(
                name: "UpdateBy",
                table: "HiringOrder");
        }
    }
}
