using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http.Timeouts;

namespace APIBitacoraDeVuelos.Modelos
{
    public class Vuelos
    {
        public int Id { get; set; }
        public DateTime DatetimeSalida { get; set; }
        public string CiudadSalida { get; set; }
        public DateTime DatetimeLlegada { get; set; }
        public string CiudadLlegada { get; set; }
        public string PNR { get; set; }
        public DateOnly FechaAbordaje { get; set; }
        public TimeOnly HoraAbordaje { get; set; }
        public DateOnly FechaRegistro { get; set; }

        [ForeignKey("Usuarios")]
        public int RegistradoPor { get; set; }
    }
}
