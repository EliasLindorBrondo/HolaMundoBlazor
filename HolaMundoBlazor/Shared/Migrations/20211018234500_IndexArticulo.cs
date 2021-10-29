using Microsoft.EntityFrameworkCore.Migrations;

namespace HolaMundoBlazor.BD.Migrations
{
    public partial class IndexArticulo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "UQ_Articulo_Cod",
                table: "Articulos",
                column: "CodArticulo",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "UQ_Articulo_Cod",
                table: "Articulos");
        }
    }
}
