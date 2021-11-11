using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class EditTabOrgnizeNameAdmin : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserNameAdmin",
                table: "orgnization",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserNameAdmin",
                table: "orgnization");
        }
    }
}
