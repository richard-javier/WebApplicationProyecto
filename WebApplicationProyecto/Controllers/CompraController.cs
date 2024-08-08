using Microsoft.AspNetCore.Mvc;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/compra")]
    [ApiController]
    public class CompraController : ControllerBase
    {
        private readonly IRepositorioCompra _repositorioCompra;

        public CompraController(IRepositorioCompra repositorioCompra)
        {
            _repositorioCompra = repositorioCompra;
        }

        [HttpPost]
        public IActionResult Create([FromBody] Compra compra)
        {
            if (compra == null)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                _repositorioCompra.Add(compra);
                return Ok(new { message = "Purchase added successfully." });
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
                var purchases = _repositorioCompra.GetAll();
                return Ok(purchases);
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
                var purchase = _repositorioCompra.GetById(id);
                if (purchase == null)
                {
                    return NotFound("Purchase not found.");
                }
                return Ok(purchase);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Compra compra)
        {
            if (compra == null || id != compra.CompraId)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingPurchase = _repositorioCompra.GetById(id);
                if (existingPurchase == null)
                {
                    return NotFound("Purchase not found.");
                }

                _repositorioCompra.Update(compra);
                return Ok("Purchase updated successfully.");
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
                var purchase = _repositorioCompra.GetById(id);
                if (purchase == null)
                {
                    return NotFound("Purchase not found.");
                }

                _repositorioCompra.Delete(id);
                return Ok("Purchase deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
