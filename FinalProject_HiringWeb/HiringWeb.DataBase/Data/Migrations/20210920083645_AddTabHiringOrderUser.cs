using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class AddTabHiringOrderUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "HiringOrderId",
                table: "AspNetUsers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "HiringOrderuser",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    HiringOrderId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HiringOrderuser", x => new { x.UserId, x.HiringOrderId });
                    table.ForeignKey(
                        name: "FK_HiringOrderuser_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_HiringOrderuser_HiringOrder_HiringOrderId",
                        column: x => x.HiringOrderId,
                        principalTable: "HiringOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_HiringOrderId",
                table: "AspNetUsers",
                column: "HiringOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_HiringOrderuser_HiringOrderId",
                table: "HiringOrderuser",
                column: "HiringOrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_HiringOrder_HiringOrderId",
                table: "AspNetUsers",
                column: "HiringOrderId",
                principalTable: "HiringOrder",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_HiringOrder_HiringOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "HiringOrderuser");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_HiringOrderId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "HiringOrderId",
                table: "AspNetUsers");
        }
    }
}
