using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProyecto.Data;
using WebApplicationProyecto.Models;

namespace WebApplicationProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InventarioController : ControllerBase
    {
        private readonly DbContext _context;

        public InventarioController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Inventario
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Inventario>>> GetInventarios()
        {
            return await _context.Inventarios.ToListAsync();
        }

        // GET: api/Inventario/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Inventario>> GetInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }
            return inventario;
        }

        // PUT: api/Inventario/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutInventario(int id, Inventario inventario)
        {
            if (id != inventario.Id)
            {
                return BadRequest();
            }

            _context.Entry(inventario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!InventarioExists(id))
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

        // POST: api/Inventario
        [HttpPost]
        public async Task<ActionResult<Inventario>> PostInventario(Inventario inventario)
        {
            _context.Inventarios.Add(inventario);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetInventario), new { id = inventario.Id }, inventario);
        }

        // DELETE: api/Inventario/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Inventario>> DeleteInventario(int id)
        {
            var inventario = await _context.Inventarios.FindAsync(id);
            if (inventario == null)
            {
                return NotFound();
            }

            _context.Inventarios.Remove(inventario);
            await _context.SaveChangesAsync();

            return inventario;
        }

        private bool InventarioExists(int id)
        {
            return _context.Inventarios.Any(e => e.Id == id);
        }
    }
}