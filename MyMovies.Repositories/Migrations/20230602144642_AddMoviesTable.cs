using Microsoft.EntityFrameworkCore.Migrations;

namespace MyMovies.Repositories.Migrations
{
    public partial class AddMoviesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MyMovies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: false),
                    Ganre = table.Column<string>(nullable: false),
                    Description = table.Column<string>(nullable: false),
                    Duration = table.Column<int>(nullable: false),
                    ImageURL = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MyMovies", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MyMovies");
        }
    }
}
