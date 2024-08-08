using Microsoft.AspNetCore.Mvc;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/venta")]
    [ApiController]
    public class VentaController : ControllerBase
    {
        private readonly IRepositorioVenta _repositorioVenta;

        public VentaController(IRepositorioVenta repositorioVenta)
        {
            _repositorioVenta = repositorioVenta;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Venta venta)
        {
            if (venta == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _repositorioVenta.Add(venta);
                return Ok(new { message = "Sale added successfully." });
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
                var sales = _repositorioVenta.GetAll();
                return Ok(sales);
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
                var sale = _repositorioVenta.GetById(id);
                if (sale == null)
                {
                    return NotFound("Sale not found.");
                }
                return Ok(sale);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Venta venta)
        {
            if (venta == null || id != venta.VentaId)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingSale = _repositorioVenta.GetById(id);
                if (existingSale == null)
                {
                    return NotFound("Sale not found.");
                }

                _repositorioVenta.Update(venta);
                return Ok("Sale updated successfully.");
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
                var sale = _repositorioVenta.GetById(id);
                if (sale == null)
                {
                    return NotFound("Sale not found.");
                }

                _repositorioVenta.Delete(id);
                return Ok("Sale deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
