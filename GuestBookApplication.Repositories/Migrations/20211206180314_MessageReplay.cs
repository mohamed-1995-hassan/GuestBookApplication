using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GuestBookApplication.Repositories.Migrations
{
    public partial class MessageReplay : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MessageReplies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    replay = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserMessageId = table.Column<int>(type: "int", nullable: false),
                    AddedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessageReplies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MessageReplies_UserMessages_UserMessageId",
                        column: x => x.UserMessageId,
                        principalTable: "UserMessages",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MessageReplies_UserMessageId",
                table: "MessageReplies",
                column: "UserMessageId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MessageReplies");
        }
    }
}
