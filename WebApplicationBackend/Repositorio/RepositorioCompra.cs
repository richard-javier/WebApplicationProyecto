using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioCompra : IRepositorioCompra
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCompra(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Compra> GetAll()
        {
            return _context.Compras.ToList();
        }

        public Compra GetById(int id)
        {
            return _context.Compras.Find(id);
        }

        public void Add(Compra compra)
        {
            _context.Compras.Add(compra);
            _context.SaveChanges();
        }

        public void Update(Compra compra)
        {
            _context.Compras.Update(compra);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var compra = _context.Compras.Find(id);
            if (compra != null)
            {
                _context.Compras.Remove(compra);
                _context.SaveChanges();
            }
        }
    }
}
