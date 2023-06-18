using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewColumnAddedToTrainDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AvailableSeats",
                table: "TrainDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvailableSeats",
                table: "TrainDetails");
        }
    }
}
