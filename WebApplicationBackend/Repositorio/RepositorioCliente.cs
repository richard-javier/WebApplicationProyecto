using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioCliente : IRepositorioCliente
    {
        private readonly ApplicationDbContext _context;

        public RepositorioCliente(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Cliente> GetAll()
        {
            return _context.Clientes.ToList();
        }

        public Cliente GetById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public void Add(Cliente cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Update(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }
    }
}
