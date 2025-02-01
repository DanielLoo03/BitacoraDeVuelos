using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBitacoraDeVuelos.Migrations
{
    /// <inheritdoc />
    public partial class AgregarAtributoHashContrasena : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "HashContrasena",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HashContrasena",
                table: "Usuarios");
        }
    }
}
