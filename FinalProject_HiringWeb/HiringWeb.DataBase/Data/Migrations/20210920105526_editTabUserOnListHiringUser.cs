using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class editTabUserOnListHiringUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HiringOrder_HiringOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HiringOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HiringOrderId",
                table: "AspNetUsers");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HiringOrderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HiringOrderId",
                table: "AspNetUsers",
                column: "HiringOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HiringOrder_HiringOrderId",
                table: "AspNetUsers",
                column: "HiringOrderId",
                principalTable: "HiringOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
