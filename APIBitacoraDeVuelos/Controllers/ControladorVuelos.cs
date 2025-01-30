using APIBitacoraDeVuelos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


namespace APIBitacoraDeVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ControladorVuelos : ControllerBase
    {
        private readonly ContextoVuelos _contextoVuelos;
        public ControladorVuelos(ContextoVuelos contextoVuelos)
        {
            _contextoVuelos = contextoVuelos;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Vuelos>>> obtenerVuelos() {
            if (_contextoVuelos.Vuelos == null) {
                return NotFound();
            }
            return await _contextoVuelos.Vuelos.ToListAsync();
        }

        [HttpGet("{Id}")]
        public async Task<ActionResult<Vuelos>> obtenerVuelo(int id) {

            if (_contextoVuelos.Vuelos is null) {
                return NotFound();
            }
            var vuelo = await _contextoVuelos.Vuelos.FindAsync(id);
            if (vuelo is null) {
                return NotFound();
            }
            return vuelo;
        
        }
    }
}
