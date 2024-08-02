using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioRegister
    {
        void Add(Register register);
        IEnumerable<Register> GetAll();
        Register GetById(int id);
        void Update(Register register);
        void Delete(int id);
    }
}
