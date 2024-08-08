using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioCliente
    {
        IEnumerable<Cliente> GetAll();
        Cliente GetById(int id);
        void Add(Cliente cliente);
        void Update(Cliente cliente);
        void Delete(int id);
    }
}
