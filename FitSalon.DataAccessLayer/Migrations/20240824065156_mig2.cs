using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace FitSalon.DataAccessLayer.Migrations
{
    public partial class mig2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Guides_EmployeeID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Destinations_ServiceID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Destinations_Guides_EmployeeID",
                table: "Destinations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Destinations_ServiceID",
                table: "Reservations");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Guides",
                table: "Guides");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations");

            migrationBuilder.RenameTable(
                name: "Guides",
                newName: "Employees");

            migrationBuilder.RenameTable(
                name: "Destinations",
                newName: "Services");

            migrationBuilder.RenameIndex(
                name: "IX_Destinations_EmployeeID",
                table: "Services",
                newName: "IX_Services_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Employees",
                table: "Employees",
                column: "EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Services",
                table: "Services",
                column: "ServiceID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Employees_EmployeeID",
                table: "Accounts",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Services_ServiceID",
                table: "Comments",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Services_ServiceID",
                table: "Reservations",
                column: "ServiceID",
                principalTable: "Services",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Services_Employees_EmployeeID",
                table: "Services",
                column: "EmployeeID",
                principalTable: "Employees",
                principalColumn: "EmployeeID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Accounts_Employees_EmployeeID",
                table: "Accounts");

            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Services_ServiceID",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Services_ServiceID",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Services_Employees_EmployeeID",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Services",
                table: "Services");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Employees",
                table: "Employees");

            migrationBuilder.RenameTable(
                name: "Services",
                newName: "Destinations");

            migrationBuilder.RenameTable(
                name: "Employees",
                newName: "Guides");

            migrationBuilder.RenameIndex(
                name: "IX_Services_EmployeeID",
                table: "Destinations",
                newName: "IX_Destinations_EmployeeID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Destinations",
                table: "Destinations",
                column: "ServiceID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Guides",
                table: "Guides",
                column: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Accounts_Guides_EmployeeID",
                table: "Accounts",
                column: "EmployeeID",
                principalTable: "Guides",
                principalColumn: "EmployeeID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Destinations_ServiceID",
                table: "Comments",
                column: "ServiceID",
                principalTable: "Destinations",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Destinations_Guides_EmployeeID",
                table: "Destinations",
                column: "EmployeeID",
                principalTable: "Guides",
                principalColumn: "EmployeeID");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Destinations_ServiceID",
                table: "Reservations",
                column: "ServiceID",
                principalTable: "Destinations",
                principalColumn: "ServiceID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
