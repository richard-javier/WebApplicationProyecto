using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationProyecto.Data;
using WebApplicationProyecto.Models;

namespace WebApplicationProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class VentaController : ControllerBase
    {
        private readonly DbContext _context;

        public VentaController(DbContext context)
        {
            _context = context;
        }

        // GET: api/Venta
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Venta>>> GetVentas()
        {
            return await _context.Ventas.ToListAsync();
        }

        // GET: api/Venta/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }
            return venta;
        }

        // POST: api/Venta
        [HttpPost]
        public async Task<ActionResult<Venta>> PostVenta(Venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetVenta), new { id = venta.Id }, venta);
        }

        // PUT: api/Venta/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutVenta(int id, Venta venta)
        {
            if (id != venta.Id)
            {
                return BadRequest();
            }

            _context.Entry(venta).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!VentaExists(id))
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

        // DELETE: api/Venta/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<Venta>> DeleteVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);
            if (venta == null)
            {
                return NotFound();
            }

            _context.Ventas.Remove(venta);
            await _context.SaveChangesAsync();

            return venta;
        }

        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(e => e.Id == id);
        }
    }