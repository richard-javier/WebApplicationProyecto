using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioVenta
    {
        IEnumerable<Venta> GetAll();
        Venta GetById(int id);
        void Add(Venta venta);
        void Update(Venta venta);
        void Delete(int id);
    }
}
