using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    /// <inheritdoc />
    public partial class SwapcolumnsinUserLikestable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_LikedUserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_LikedUserId",
                table: "UserLikes",
                column: "LikedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_LikedUserId",
                table: "UserLikes");

            migrationBuilder.DropForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes");

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_LikedUserId",
                table: "UserLikes",
                column: "LikedUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UserLikes_AspNetUsers_UserId",
                table: "UserLikes",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }
    }
}
