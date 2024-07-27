using Microsoft.AspNetCore.Mvc;
using WebApplicationProyecto.Data;
using WebApplicationProyecto.Models;
using System.Threading.Tasks;

namespace WebApplicationProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RecuperarContraseñaController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IEmailService _emailService;

        public RecuperarContraseñaController(DbContext context, IEmailService emailService)
        {
            _context = context;
            _emailService = emailService;
        }

        // POST: api/RecuperarContraseña
        [HttpPost]
        public async Task<ActionResult> RecuperarContraseña(RecuperarContraseñaModel model)
        {
            var user = await _context.Users.FindAsync(model.Username);
            if (user == null)
            {
                return NotFound("Usuario no encontrado");
            }

            var token = await _emailService.GenerateToken(user);
            await _emailService.SendEmailAsync(user.Email, "Recuperar contraseña", $"Por favor, haga clic en el siguiente enlace para recuperar su contraseña: <a href='{token}'>Recuperar contraseña</a>");

            return Ok("Se ha enviado un correo electrónico con instrucciones para recuperar su contraseña");
        }
    }
}