using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class UserAndRoleModelsChanged : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Role_id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                column: "Role_id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Users_Role_id",
                table: "Users");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                column: "Role_id",
                unique: true);
        }
    }
}
