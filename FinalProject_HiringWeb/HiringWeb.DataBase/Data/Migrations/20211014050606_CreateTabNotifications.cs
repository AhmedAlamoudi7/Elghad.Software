using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Hiring.Web_FinalProject_VisionPlus_ASP.NetCore.Data.Migrations
{
    public partial class CreateTabNotifications : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "NotificationsDbEntity",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserSubjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    UserObjectId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    HiringOrderId = table.Column<int>(type: "int", nullable: true),
                    NotificationTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NotificationType = table.Column<int>(type: "int", nullable: false),
                    NotificationTypeDes = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_NotificationsDbEntity", x => x.Id);
                    table.ForeignKey(
                        name: "FK_NotificationsDbEntity_AspNetUsers_UserObjectId",
                        column: x => x.UserObjectId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationsDbEntity_AspNetUsers_UserSubjectId",
                        column: x => x.UserSubjectId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_NotificationsDbEntity_HiringOrder_HiringOrderId",
                        column: x => x.HiringOrderId,
                        principalTable: "HiringOrder",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsDbEntity_HiringOrderId",
                table: "NotificationsDbEntity",
                column: "HiringOrderId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsDbEntity_UserObjectId",
                table: "NotificationsDbEntity",
                column: "UserObjectId");

            migrationBuilder.CreateIndex(
                name: "IX_NotificationsDbEntity_UserSubjectId",
                table: "NotificationsDbEntity",
                column: "UserSubjectId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "NotificationsDbEntity");
        }
    }
}
