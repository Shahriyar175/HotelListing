using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace HotelListing.Migrations
{
    /// <inheritdoc />
    public partial class AddedRoles : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "dd95fcd7-ea0d-414c-9c01-722d9feaf2bc", null, "User", "USER" },
                    { "f7e21283-5b8c-468e-a4f5-c5b09cc86df3", null, "Admin", "ADMIN" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "dd95fcd7-ea0d-414c-9c01-722d9feaf2bc");

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "f7e21283-5b8c-468e-a4f5-c5b09cc86df3");
        }
    }
}
