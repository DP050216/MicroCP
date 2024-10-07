using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MicroServicioCP.Entidades.Context
{
    public class ClienteContext : PersonasContext
    {
        [Key]
        public int ClienteID { get; set; }
        public required string Contrasena { get; set; }
        public bool Estado { get; set; }
    }
}
