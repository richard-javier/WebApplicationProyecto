using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioVenta : IRepositorioVenta
    {
        private readonly ApplicationDbContext _context;

        public RepositorioVenta(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Venta> GetAll()
        {
            return _context.Ventas.ToList();
        }

        public Venta GetById(int id)
        {
            return _context.Ventas.Find(id);
        }

        public void Add(Venta venta)
        {
            _context.Ventas.Add(venta);
            _context.SaveChanges();
        }

        public void Update(Venta venta)
        {
            _context.Ventas.Update(venta);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var venta = _context.Ventas.Find(id);
            if (venta != null)
            {
                _context.Ventas.Remove(venta);
                _context.SaveChanges();
            }
        }
    }
}
