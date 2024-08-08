using Microsoft.AspNetCore.Mvc;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventarioController : ControllerBase
    {
        private readonly IRepositorioInventario _repositorioInventario;

        public InventarioController(IRepositorioInventario repositorioInventario)
        {
            _repositorioInventario = repositorioInventario;
        }

        // GET: api/inventario
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var inventoryItems = _repositorioInventario.GetAll();
                return Ok(inventoryItems);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // GET: api/inventario/{id}
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var inventoryItem = _repositorioInventario.GetById(id);
                if (inventoryItem == null)
                {
                    return NotFound("Inventory item not found.");
                }
                return Ok(inventoryItem);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // POST: api/inventario
        [HttpPost]
        public IActionResult Create([FromBody] Producto inventario)
        {
            if (inventario == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _repositorioInventario.Add(inventario);
                return CreatedAtAction(nameof(GetById), new { id = inventario.ProductoId }, inventario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // PUT: api/inventario/{id}
        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Producto inventario)
        {
            if (inventario == null || id != inventario.ProductoId)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingInventoryItem = _repositorioInventario.GetById(id);
                if (existingInventoryItem == null)
                {
                    return NotFound("Inventory item not found.");
                }

                _repositorioInventario.Update(inventario);
                return Ok("Inventory item updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        // DELETE: api/inventario/{id}
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var inventoryItem = _repositorioInventario.GetById(id);
                if (inventoryItem == null)
                {
                    return NotFound("Inventory item not found.");
                }

                _repositorioInventario.Delete(id);
                return NoContent(); // Use NoContent() to indicate successful deletion
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
