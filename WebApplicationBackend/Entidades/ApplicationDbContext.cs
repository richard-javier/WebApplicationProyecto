using Microsoft.EntityFrameworkCore;
using WebApplicationBackend.Entidades;

namespace WebApplicationBackend
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Login> Logins { get; set; }
        public DbSet<Register> Registers { get; set; }
        public DbSet<ForgotPassword> ForgotPasswords { get; set; }
        public DbSet<ListaRegistros> ListaRegistros { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(
                    "Server=.\\SQLEXPRESS;Database=Proyecto-curso;Trusted_Connection=True;MultipleActiveResultSets=true; TrustServerCertificate=True;",
                    options => options.MigrationsAssembly("WebApplicationBackend")
                );
            }
        }
    }
}
