using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioCompra
    {
        IEnumerable<Compra> GetAll();
        Compra GetById(int id);
        void Add(Compra compra);
        void Update(Compra compra);
        void Delete(int id);
    }
}
