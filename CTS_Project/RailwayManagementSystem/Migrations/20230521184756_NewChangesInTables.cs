using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RailwayManagementSystem.Migrations
{
    /// <inheritdoc />
    public partial class NewChangesInTables : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Role_id",
                table: "Users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "TicketDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Class_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Payment_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Ticket_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Train_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "User_id",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Users_Role_id",
                table: "Users",
                column: "Role_id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TicketDetails_User_id",
                table: "TicketDetails",
                column: "User_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Class_id",
                table: "Reservations",
                column: "Class_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Payment_id",
                table: "Reservations",
                column: "Payment_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Ticket_id",
                table: "Reservations",
                column: "Ticket_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Train_id",
                table: "Reservations",
                column: "Train_id");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_User_id",
                table: "Reservations",
                column: "User_id");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Classes_Class_id",
                table: "Reservations",
                column: "Class_id",
                principalTable: "Classes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Payments_Payment_id",
                table: "Reservations",
                column: "Payment_id",
                principalTable: "Payments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TicketDetails_Ticket_id",
                table: "Reservations",
                column: "Ticket_id",
                principalTable: "TicketDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_TrainDetails_Train_id",
                table: "Reservations",
                column: "Train_id",
                principalTable: "TrainDetails",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Users_User_id",
                table: "Reservations",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TicketDetails_Users_User_id",
                table: "TicketDetails",
                column: "User_id",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Roles_Role_id",
                table: "Users",
                column: "Role_id",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Classes_Class_id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Payments_Payment_id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TicketDetails_Ticket_id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_TrainDetails_Train_id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Users_User_id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_TicketDetails_Users_User_id",
                table: "TicketDetails");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Roles_Role_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Users_Role_id",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_TicketDetails_User_id",
                table: "TicketDetails");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Class_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Payment_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Ticket_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Train_id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_User_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Role_id",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "TicketDetails");

            migrationBuilder.DropColumn(
                name: "Class_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Payment_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Ticket_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "Train_id",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "User_id",
                table: "Reservations");
        }
    }
}
