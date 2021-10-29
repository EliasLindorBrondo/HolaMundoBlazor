using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaMundoBlazor.BD.Migrations
{
    public partial class Articulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Articulos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodArticulo = table.Column<string>(type: "nvarchar(5)", maxLength: 5, nullable: false),
                    NombreArticulo = table.Column<string>(type: "nvarchar(120)", maxLength: 120, nullable: false),
                    UnidadArticulo = table.Column<int>(type: "int", maxLength: 5, nullable: false),
                    CantidadArticulo = table.Column<int>(type: "int", maxLength: 10, nullable: false),
                    DescripcionArticulo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Categoria = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Articulos", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Articulos");
        }
    }
}
