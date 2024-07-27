using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProyecto.Data;
using WebApplicationProyecto.Models;

namespace WebApplicationProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CompraController : ControllerBase
    {
        private readonly DbContext _context;

        public CompraController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Compra
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Compra>>> GetCompras()
        {
            return await _context.Compras.ToListAsync();
        }

        // GET: api/Compra/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Compra>> GetCompra(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }
            return compra;
        }

        // POST: api/Compra
        [HttpPost]
        public async Task<ActionResult<Compra>> PostCompra(Compra compra)
        {
            _context.Compras.Add(compra);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetCompra), new { id = compra.Id }, compra);
        }

        // PUT: api/Compra/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompra(int id, Compra compra)
        {
            if (id != compra.Id)
            {
                return BadRequest();
            }

            _context.Entry(compra).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompraExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // DELETE: api/Compra/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Compra>> DeleteCompra(int id)
        {
            var compra = await _context.Compras.FindAsync(id);
            if (compra == null)
            {
                return NotFound();
            }

            _context.Compras.Remove(compra);
            await _context.SaveChangesAsync();

            return compra;
        }

        private bool CompraExists(int id)
        {
            return _context.Compras.Any(e => e.Id == id);
        }
    }
}