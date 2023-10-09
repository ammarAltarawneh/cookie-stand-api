using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cookieStands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[] { "bla bla", "Barcelona", 4, 2, "Ali" });

            migrationBuilder.UpdateData(
                table: "cookieStands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageCookiesPerSale", "Owner" },
                values: new object[] { 1.75, "Salma" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "cookieStands",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[] { "description1", "Amman", 7, 3, "Person1" });

            migrationBuilder.UpdateData(
                table: "cookieStands",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "AverageCookiesPerSale", "Owner" },
                values: new object[] { 2.5, "Person2" });
        }
    }
}
