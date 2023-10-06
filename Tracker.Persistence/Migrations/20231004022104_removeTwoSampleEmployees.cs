using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Tracker.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class removeTwoSampleEmployees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.RenameColumn(
                name: "photoPath",
                table: "Employees",
                newName: "PhotoPath");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Ishaya.Haruna@gloworld.com", "Ishaya", "Haruna", 2 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Prisha.Ravi@gloworld.com", "Prisha", "Ravi", 1 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Aminat.Musa@gloworld.com", "Chuks", "Wale", 3 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "PhotoPath",
                table: "Employees",
                newName: "photoPath");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Taiwo.Dele@gloworld.com", "Taiwo", "Dele", 4 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Daniel.Chuks@gloworld.com", "Daniel", "Chuks", 5 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "Email", "FirstName", "SurName", "Unit" },
                values: new object[] { "Ishaya.Haruna@gloworld.com", "Ishaya", "Haruna", 2 });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "Id", "Email", "FirstName", "SurName", "Unit", "photoPath" },
                values: new object[,]
                {
                    { 4, "Prisha.Ravi@gloworld.com", "Prisha", "Ravi", 1, null },
                    { 5, "Aminat.Musa@gloworld.com", "Aminat", "Musa", 3, null }
                });
        }
    }
}
