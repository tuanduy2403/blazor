using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorBackend.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comics",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comics", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "USers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ComicId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_USers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_USers_Comics_ComicId",
                        column: x => x.ComicId,
                        principalTable: "Comics",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 1, "Checking" });

            migrationBuilder.InsertData(
                table: "Comics",
                columns: new[] { "Id", "Name" },
                values: new object[] { 2, "Controller" });

            migrationBuilder.InsertData(
                table: "USers",
                columns: new[] { "Id", "ComicId", "Email", "FirstName", "LastName" },
                values: new object[] { 1, 1, "email@gmail.com", "Checking", "Controller" });

            migrationBuilder.InsertData(
                table: "USers",
                columns: new[] { "Id", "ComicId", "Email", "FirstName", "LastName" },
                values: new object[] { 2, 2, "checking@gmail.com", "Design", "Maintain" });

            migrationBuilder.CreateIndex(
                name: "IX_USers_ComicId",
                table: "USers",
                column: "ComicId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "USers");

            migrationBuilder.DropTable(
                name: "Comics");
        }
    }
}
