using Microsoft.AspNetCore.Mvc;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/register")]
    [ApiController]
    public class RegisterController : ControllerBase
    {
        private readonly IRepositorioRegister _repositorioRegister;

        public RegisterController(IRepositorioRegister repositorioRegister)
        {
            _repositorioRegister = repositorioRegister;
        }

        [HttpPost]
        public IActionResult Register([FromBody] Register register)
        {
            if (register == null)
            {
                return BadRequest("Invalid data.");
            }

            _repositorioRegister.Add(register);
            return Ok("Registration successful.");
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            var users = _repositorioRegister.GetAll();
            return Ok(users);
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _repositorioRegister.GetById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }
            return Ok(user);
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Register register)
        {
            if (register == null || id != register.Id)
            {
                return BadRequest("Invalid data.");
            }

            var existingUser = _repositorioRegister.GetById(id);
            if (existingUser == null)
            {
                return NotFound("User not found.");
            }

            _repositorioRegister.Update(register);
            return Ok("User updated successfully.");
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var user = _repositorioRegister.GetById(id);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            _repositorioRegister.Delete(id);
            return Ok("User deleted successfully.");
        }
    }
}
