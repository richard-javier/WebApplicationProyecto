using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioListaRegistros
    {
        IEnumerable<ListaRegistros> GetAll();
        ListaRegistros GetById(int id);
        void Add(ListaRegistros listaRegistros);
        void Update(ListaRegistros listaRegistros);
        void Delete(int id);
    }
}
