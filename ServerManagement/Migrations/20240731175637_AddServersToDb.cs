using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ServerManagement.Migrations
{
    /// <inheritdoc />
    public partial class AddServersToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Servers",
                columns: table => new
                {
                    ServerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServerName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServerCity = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsOnline = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Servers", x => x.ServerId);
                });

            migrationBuilder.InsertData(
                table: "Servers",
                columns: new[] { "ServerId", "IsOnline", "ServerCity", "ServerName" },
                values: new object[,]
                {
                    { 1, true, "Toronto", "Server1" },
                    { 2, true, "Toronto", "Server2" },
                    { 3, true, "Toronto", "Server3" },
                    { 4, false, "Montreal", "Server4" },
                    { 5, true, "Montreal", "Server5" },
                    { 6, true, "Montreal", "Server6" },
                    { 7, true, "Halifax", "Server7" },
                    { 8, true, "Halifax", "Server8" },
                    { 9, true, "Halifax", "Server9" },
                    { 10, false, "Calgary", "Server10" },
                    { 11, true, "Calgary", "Server11" },
                    { 12, true, "Ottawa", "Server12" },
                    { 13, true, "Ottawa", "Server13" },
                    { 14, true, "Ottawa", "Server14" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Servers");
        }
    }
}
