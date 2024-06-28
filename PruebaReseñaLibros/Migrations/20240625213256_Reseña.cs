using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaReseñaLibros.Migrations
{
    /// <inheritdoc />
    public partial class Reseña : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Reseña",
                columns: table => new
                {
                    idReseña = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    idLibro = table.Column<int>(type: "int", nullable: false),
                    Contenido = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Usuario = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    LibrosIdTitulo = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reseña", x => x.idReseña);
                    table.ForeignKey(
                        name: "FK_Reseña_Libro_LibrosIdTitulo",
                        column: x => x.LibrosIdTitulo,
                        principalTable: "Libro",
                        principalColumn: "IdTitulo");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Reseña_LibrosIdTitulo",
                table: "Reseña",
                column: "LibrosIdTitulo");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Reseña");
        }
    }
}
