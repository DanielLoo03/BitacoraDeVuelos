using Microsoft.EntityFrameworkCore;

namespace APIBitacoraDeVuelos.Modelos
{
    public class ContextoVuelos:DbContext
    {
        public ContextoVuelos(DbContextOptions<ContextoVuelos> options)
            : base(options)
        { 
            
        }

        public DbSet<Vuelos> Vuelos { get; set; } = null!;

    }
}
