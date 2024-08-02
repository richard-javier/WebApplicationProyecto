using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioLogin
    {
        IEnumerable<Login> GetAll();
        Login GetById(int id);
        void Add(Login login);
        void Update(Login login);
        void Delete(int id);
    }
}
