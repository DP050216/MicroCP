namespace MicroServicioCP.Entidades.Request
{
    public class PersonasRequest
    {
        public required string Nombres { get; set; }
        public required string Identificacion { get; set; }
        public required string Direccion { get; set; }
        public required string Telefono { get; set; }
        public required string Estado { get; set; }
    }
}
