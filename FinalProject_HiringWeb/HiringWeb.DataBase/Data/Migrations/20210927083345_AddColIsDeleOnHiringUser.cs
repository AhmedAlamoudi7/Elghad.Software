using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class AddColIsDeleOnHiringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsDelete",
                table: "HiringOrderuser",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsDelete",
                table: "HiringOrderuser");
        }
    }
}
