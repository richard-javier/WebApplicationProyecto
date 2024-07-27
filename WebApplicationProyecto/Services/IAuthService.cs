using System.Threading.Tasks;

namespace WebApplicationProyecto.Services
{
    public interface IAuthService
    {
        Task<string> GenerateToken(User user);
        Task<bool> VerifyPasswordHash(string password, string passwordHash);
    }
}