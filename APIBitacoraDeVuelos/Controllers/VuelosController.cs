using APIBitacoraDeVuelos.Modelos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIBitacoraDeVuelos.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VuelosController : ControllerBase
    {
        private readonly ContextoVuelos _contextoVuelos;
        public VuelosController(ContextoVuelos contextoVuelos)
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

        [HttpGet("{PNR}")]
        public async Task<ActionResult<Vuelos>> obtenerVuelo(string PNR) {
            if (_contextoVuelos.Vuelos is null) {
                return NotFound();
            }
            var vuelo = await _contextoVuelos.Vuelos.FirstOrDefaultAsync(v => v.PNR == PNR);
            if (vuelo is null) {
                return NotFound();
            }
            return vuelo;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UsuariosLogin request)
        {
            if (string.IsNullOrEmpty(request.Correo) || string.IsNullOrEmpty(request.Contrasena))
                return BadRequest("El correo y la contraseña son obligatorios.");

            var usuario = await _contextoVuelos.Usuarios.FirstOrDefaultAsync(u => u.Correo == request.Correo);

            if (usuario == null || !BCrypt.Net.BCrypt.Verify(request.Contrasena, usuario.HashContrasena))
                return Ok(new { success = false, message = "Credenciales incorrectas."});

            return Ok(new { success = true, message = "Login exitoso"});
        }

        [HttpPost("registrarVuelo")]
        public async Task<ActionResult<Vuelos>> registrarVuelo([FromBody] Vuelos vuelo) {
            _contextoVuelos.Vuelos.Add(vuelo);
            await _contextoVuelos.SaveChangesAsync();
            return CreatedAtAction(nameof(obtenerVuelo), new { PNR = vuelo.PNR }, vuelo);
        }
    }
}
