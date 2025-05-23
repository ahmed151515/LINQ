using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace IEnumerableVsIQueryable.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "Id", "Author", "Price", "Title" },
                values: new object[,]
                {
                    { 10, "Herbert Schildt", 52.12m, "Java: The Complete Reference" },
                    { 11, "Joan Casteel", 167.53m, "Oracle 11g" },
                    { 12, " Brahmanand Shukla", 37.99m, "Learn T-SQL" },
                    { 13, "C++ Programming Language", 105.18m, "C++ Programming Language" },
                    { 14, "Clive Campbell", 41.99m, "PYTHON PROGRAMMING" },
                    { 15, " David Flanagan", 53.32m, "JavaScript: The Definitive" },
                    { 16, "Steve Eichert", 45.99m, "LINQ In Action" },
                    { 17, "Jon Skeet", 49.99m, "C# in Depth" },
                    { 18, "Learning SQL", 46.26m, "Learning SQL" },
                    { 19, "Fullstack Vue", 51.07m, "Fullstack Vue" },
                    { 20, "The Road to React", 37.08m, "The Road to React" },
                    { 21, "Dan Appleman", 44.99m, "Moving To VB.NET" },
                    { 22, "Jeremy Wilken", 59.99m, "Angular in Action" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
