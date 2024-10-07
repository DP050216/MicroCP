using System;

namespace MicroServicioCP.Entidades.Context
{
    public class PersonasContext
    {
        public required string Nombres { get; set; }
        public string? Genero { get; set; }
        public int Edad { get; set; }
        public required string Identificacion { get; set; }
        public  string? Direccion { get; set; }
        public  string? Telefono { get; set; }
    }


}
