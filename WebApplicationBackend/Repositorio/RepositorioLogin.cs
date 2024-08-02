using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioLogin : IRepositorioLogin
    {
        private readonly ApplicationDbContext _context;

        public RepositorioLogin(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Login> GetAll()
        {
            return _context.Logins.ToList();
        }

        public Login GetById(int id)
        {
            return _context.Logins.Find(id);
        }

        public void Add(Login login)
        {
            _context.Logins.Add(login);
            _context.SaveChanges();
        }

        public void Update(Login login)
        {
            _context.Logins.Update(login);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var login = _context.Logins.Find(id);
            if (login != null)
            {
                _context.Logins.Remove(login);
                _context.SaveChanges();
            }
        }
    }
}
