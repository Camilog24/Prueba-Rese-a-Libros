using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PruebaReseñaLibros.Migrations
{
    /// <inheritdoc />
    public partial class actualizacionerrores : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagenLibro",
                table: "Libro",
                type: "varbinary(max)",
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(500)",
                oldMaxLength: 500);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<byte[]>(
                name: "ImagenLibro",
                table: "Libro",
                type: "varbinary(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(byte[]),
                oldType: "varbinary(max)");
        }
    }
}
