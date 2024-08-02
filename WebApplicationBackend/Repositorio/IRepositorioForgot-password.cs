using System.Collections.Generic;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public interface IRepositorioForgotPassword
    {
        IEnumerable<ForgotPassword> GetAll();
        ForgotPassword GetById(int id);
        void Add(ForgotPassword forgotPassword);
        void Update(ForgotPassword forgotPassword);
        void Delete(int id);
    }
}
