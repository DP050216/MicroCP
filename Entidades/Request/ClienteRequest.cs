using MicroServicioCP.Entidades.Response;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MicroServicioCP.Entidades.Request
{
    public class ClienteRequest : PersonasRequest
    {
        
        public required int ClienteID { get; set; }
        public required string Contrasena { get; set; }
    }
}
