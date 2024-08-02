using System.Collections.Generic;
using System.Linq;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend.Repositorio
{
    public class RepositorioRegister : IRepositorioRegister
    {
        private readonly ApplicationDbContext _context;

        public RepositorioRegister(ApplicationDbContext context)
        {
            _context = context;
        }

        public void Add(Register register)
        {
            _context.Registers.Add(register);
            _context.SaveChanges();
        }

        public IEnumerable<Register> GetAll()
        {
            return _context.Registers.ToList();
        }

        public Register GetById(int id)
        {
            return _context.Registers.Find(id);
        }

        public void Update(Register register)
        {
            _context.Registers.Update(register);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var register = _context.Registers.Find(id);
            if (register != null)
            {
                _context.Registers.Remove(register);
                _context.SaveChanges();
            }
        }
    }
}
