using AutoMapper;
using MicroServicioCP.DBContext;
using MicroServicioCP.Entidades.Context;
using MicroServicioCP.Entidades.Request;
using MicroServicioCP.Entidades.Response;
using Microsoft.AspNetCore.Mvc;

namespace MicroCP.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ClientesController : Controller
    {
        private readonly AppDbContext _appDbContext;
        private ResponseInformation _response;
        private readonly IMapper _mapper;


        public ClientesController(AppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _response = new ResponseInformation();
            _mapper = mapper;
        }

        [HttpGet]
        public ResponseInformation GetCliente()
        {
            try
            {
                IEnumerable<ClienteContext> lstClientes = _appDbContext.Cliente.ToList();
                _response.Data = lstClientes;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }

            return _response;
        }

        [HttpPost]
        public ResponseInformation PostCliente([FromBody] ClienteRequest reqCliente)
        {
            try
            {
                var clienteContext = _mapper.Map<ClienteContext>(reqCliente);
                _appDbContext.Cliente.Add(clienteContext);
                _appDbContext.SaveChanges();
                _response.Data = reqCliente;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            _response.Message = _response.Success ? "Registro exitoso" : "Error al insertar registro. " + _response.Message;
            return _response;
        }

        [HttpPatch]
        public ResponseInformation PatchCliente([FromBody] ClienteRequest reqCliente)
        {
            try
            {
                var clienteContext = _mapper.Map<ClienteContext>(reqCliente);
                _appDbContext.Cliente.Update(clienteContext);
                _appDbContext.SaveChanges();
                _response.Data = reqCliente;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpPut]
        public ResponseInformation PutCliente([FromBody] ClienteRequest reqCliente)
        {
            try
            {
                var clienteContext = _mapper.Map<ClienteContext>(reqCliente);
                _appDbContext.Cliente.Update(clienteContext);
                _appDbContext.SaveChanges();
                _response.Data = reqCliente;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpDelete]
        public ResponseInformation DeleteCliente(int id)
        {
            try
            {
                ClienteContext cliente = _appDbContext.Cliente.FirstOrDefault(c => c.ClienteID == id);
                _appDbContext.Cliente.Remove(cliente);
                _appDbContext.SaveChanges();
                _response.Data = cliente;
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }

        [HttpGet("Interconexion")]
        public async Task<ResponseInformation> ConsultaMovClienteAsync()
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        string url = "https://localhost:7245/Movimientos/Fecha?dtFechaInicio=10%2F06%2F2024&dtFechaFin=10%2F07%2F2024";
                        HttpResponseMessage response = await client.GetAsync(url);
                        if (response.IsSuccessStatusCode)
                        {
                            // Leer la respuesta como una cadena
                            string responseData = await response.Content.ReadAsStringAsync();
                            _response.Message = responseData;
                        }
                        else
                        {
                            _response.Message = $"Error: {response.StatusCode}";
                        }
                    }
                    catch (HttpRequestException e)
                    {
                        _response.Message = $"Error de solicitud HTTP: {e.Message}";
                    }
                }
            }
            catch (Exception ex)
            {
                _response.Success = false;
                _response.Message = ex.Message;
            }
            return _response;
        }
    }
}
