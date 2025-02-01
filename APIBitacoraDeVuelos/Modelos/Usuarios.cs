namespace APIBitacoraDeVuelos.Modelos
{
    public class Usuarios
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Correo { get; set; }
        public string Contrasena { get; set; }
        public string HashContrasena { get; set; }
    }
}
