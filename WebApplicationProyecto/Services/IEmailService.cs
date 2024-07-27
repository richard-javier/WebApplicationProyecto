using System.Threading.Tasks;

namespace WebApplicationProyecto.Services
{
    public interface IEmailService
    {
        Task SendEmailAsync(string email, string subject, string body);
        Task<string> GenerateToken(User user);
    }
}