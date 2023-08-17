using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Layer.Access.Migrations
{
    /// <inheritdoc />
    public partial class mig3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_EntitiesId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "EntitiesId",
                table: "Products",
                newName: "UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_EntitiesId",
                table: "Products",
                newName: "IX_Products_UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_Users_UserId",
                table: "Products");

            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "Products",
                newName: "EntitiesId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_UserId",
                table: "Products",
                newName: "IX_Products_EntitiesId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Users_EntitiesId",
                table: "Products",
                column: "EntitiesId",
                principalTable: "Users",
                principalColumn: "Id");
        }
    }
}
