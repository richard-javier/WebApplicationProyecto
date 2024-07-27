using Microsoft.AspNetCore.Mvc;
using WebApplicationProyecto.Data;
using WebApplicationProyecto.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace WebApplicationProyecto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly DbContext _context;
        private readonly IAuthenticationService _authenticationService;

        public LoginController(DbContext context, IAuthenticationService authenticationService)
        {
            _context = context;
            _authenticationService = authenticationService;
        }

        // POST: api/Login
        [HttpPost]
        public async Task<ActionResult<string>> Login(LoginModel model)
        {
            var user = await _context.Users.FindAsync(model.Username);
            if (user == null)
            {
                return Unauthorized("Invalid username or password");
            }

            if (!_authenticationService.VerifyPasswordHash(model.Password, user.PasswordHash))
            {
                return Unauthorized("Invalid username or password");
            }

            var token = await _authenticationService.GenerateToken(user);
            return Ok(token);
        }
    }
}