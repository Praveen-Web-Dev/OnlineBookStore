using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Bulky.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class CompanyModelFinaled : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Companies",
                columns: new[] { "Id", "City", "Name", "PhoneNumber", "PostalCode", "State", "StreetAddress" },
                values: new object[,]
                {
                    { 1, "Tech City", "Tech Solution", "7989792020", "S3 7GE", "England", "123 Tech St" },
                    { 2, "Admin City", "Admin Solution", "7989792021", "A1 2BC", "England", "456 Admin St" },
                    { 3, "Software City", "Software Solution", "7989792022", "S4 5DE", "England", "789 Software St" },
                    { 4, "Code City", "Code Solution", "7989792023", "C6 7FG", "England", "101 Code St" },
                    { 5, "Design City", "Design Solution", "7989792024", "D8 9HI", "England", "202 Design St" },
                    { 6, "Marketing City", "Marketing Solution", "7989792025", "M1 2JK", "England", "303 Marketing St" },
                    { 7, "Consulting City", "Consulting Solution", "7989792026", "C3 4LM", "England", "404 Consulting St" },
                    { 8, "Business City", "Business Solution", "7989792027", "B5 6NO", "England", "505 Business St" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Companies",
                keyColumn: "Id",
                keyValue: 8);
        }
    }
}
