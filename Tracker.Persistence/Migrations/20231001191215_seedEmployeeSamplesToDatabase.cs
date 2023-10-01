using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class seedEmployeeSamplesToDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_States_StateId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_StateId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "Gender",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "IsStillEmployee",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StaffId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StaffPhone",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "StateId",
                table: "Employees");

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "SurName", "Unit", "photoPath" },
                values: new object[,]
                {
                    { 1, "Taiwo.Dele@gloworld.com", "Taiwo", "Dele", "SPOC", null },
                    { 2, "Daniel.Chuks@gloworld.com", "Daniel", "Chuks", "Tech Projects", null },
                    { 3, "Ishaya.Haruna@gloworld.com", "Ishaya", "Haruna", "Tech Operations", null },
                    { 4, "Prisha.Ravi@gloworld.com", "Prisha", "Ravi", "Sales", null },
                    { 5, "Aminat.Musa@gloworld.com", "Aminat", "Musa", "Service Management", null }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.AddColumn<string>(
                name: "Gender",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsStillEmployee",
                table: "Employees",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "StaffId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "StaffPhone",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StateId",
                table: "Employees",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_StateId",
                table: "Employees",
                column: "StateId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_States_StateId",
                table: "Employees",
                column: "StateId",
                principalTable: "States",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
