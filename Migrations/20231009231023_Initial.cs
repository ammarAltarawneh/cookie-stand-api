using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace cookie_stand_api.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "cookieStands",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Location = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MinimumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    MaximumCustomersPerHour = table.Column<int>(type: "int", nullable: false),
                    AverageCookiesPerSale = table.Column<double>(type: "float", nullable: false),
                    Owner = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_cookieStands", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "hourlySales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StandCookieId = table.Column<int>(type: "int", nullable: false),
                    salesvalue = table.Column<int>(type: "int", nullable: false),
                    cookieStandId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_hourlySales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_hourlySales_cookieStands_cookieStandId",
                        column: x => x.cookieStandId,
                        principalTable: "cookieStands",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "cookieStands",
                columns: new[] { "Id", "AverageCookiesPerSale", "Description", "Location", "MaximumCustomersPerHour", "MinimumCustomersPerHour", "Owner" },
                values: new object[,]
                {
                    { 1, 2.5, "description1", "Amman", 7, 3, "Person1" },
                    { 2, 2.5, "description2", "Irbid", 7, 3, "Person2" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_hourlySales_cookieStandId",
                table: "hourlySales",
                column: "cookieStandId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "hourlySales");

            migrationBuilder.DropTable(
                name: "cookieStands");
        }
    }
}
