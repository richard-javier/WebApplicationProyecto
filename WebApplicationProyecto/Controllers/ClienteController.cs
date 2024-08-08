using Microsoft.AspNetCore.Mvc;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/cliente")]
    [ApiController]
    public class ClienteController : ControllerBase
    {
        private readonly IRepositorioCliente _repositorioCliente;

        public ClienteController(IRepositorioCliente repositorioCliente)
        {
            _repositorioCliente = repositorioCliente;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Cliente cliente)
        {
            if (cliente == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _repositorioCliente.Add(cliente);
                return Ok(new { message = "Client added successfully." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var clients = _repositorioCliente.GetAll();
                return Ok(clients);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var client = _repositorioCliente.GetById(id);
                if (client == null)
                {
                    return NotFound("Client not found.");
                }
                return Ok(client);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Cliente cliente)
        {
            if (cliente == null || id != cliente.ClienteId)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingClient = _repositorioCliente.GetById(id);
                if (existingClient == null)
                {
                    return NotFound("Client not found.");
                }

                _repositorioCliente.Update(cliente);
                return Ok("Client updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var client = _repositorioCliente.GetById(id);
                if (client == null)
                {
                    return NotFound("Client not found.");
                }

                _repositorioCliente.Delete(id);
                return Ok("Client deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
