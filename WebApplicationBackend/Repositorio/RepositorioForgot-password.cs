using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioForgotPassword : IRepositorioForgotPassword
    {
        private readonly ApplicationDbContext _context;

        public RepositorioForgotPassword(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<ForgotPassword> GetAll()
        {
            return _context.ForgotPasswords.ToList();
        }

        public ForgotPassword GetById(int id)
        {
            return _context.ForgotPasswords.FirstOrDefault(fp => fp.Id == id);
        }

        public void Add(ForgotPassword forgotPassword)
        {
            _context.ForgotPasswords.Add(forgotPassword);
            _context.SaveChanges();
        }

        public void Update(ForgotPassword forgotPassword)
        {
            _context.ForgotPasswords.Update(forgotPassword);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var forgotPassword = _context.ForgotPasswords.FirstOrDefault(fp => fp.Id == id);
            if (forgotPassword != null)
            {
                _context.ForgotPasswords.Remove(forgotPassword);
                _context.SaveChanges();
            }
        }
    }
}
