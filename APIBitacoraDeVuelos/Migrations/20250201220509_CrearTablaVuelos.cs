using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace APIBitacoraDeVuelos.Migrations
{
    /// <inheritdoc />
    public partial class CrearTablaVuelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vuelos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DatetimeSalida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CiudadSalida = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DatetimeLlegada = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CiudadLlegada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PNR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FechaAbordaje = table.Column<DateOnly>(type: "date", nullable: false),
                    HoraAbordaje = table.Column<TimeOnly>(type: "time", nullable: false),
                    FechaRegistro = table.Column<DateOnly>(type: "date", nullable: false),
                    RegistradoPor = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vuelos", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vuelos");
        }
    }
}
