using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioInventario
    {
        IEnumerable<Producto> GetAll();
        Producto GetById(int id);
        void Add(Producto producto);
        void Update(Producto producto);
        void Delete(int id);
    }
}
