using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioListaRegistros : IRepositorioListaRegistros
    {
        private readonly ApplicationDbContext _context;

        public RepositorioListaRegistros(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ListaRegistros> GetAll()
        {
            return _context.ListaRegistros.ToList();
        }

        public ListaRegistros GetById(int id)
        {
            return _context.ListaRegistros.Find(id);
        }

        public void Add(ListaRegistros listaRegistros)
        {
            _context.ListaRegistros.Add(listaRegistros);
            _context.SaveChanges();
        }

        public void Update(ListaRegistros listaRegistros)
        {
            _context.ListaRegistros.Update(listaRegistros);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var listaRegistros = _context.ListaRegistros.Find(id);
            if (listaRegistros != null)
            {
                _context.ListaRegistros.Remove(listaRegistros);
                _context.SaveChanges();
            }
        }
    }
}
