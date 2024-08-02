using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IRepositorioLogin _repositorioLogin;

        public LoginController(IRepositorioLogin repositorioLogin)
        {
            _repositorioLogin = repositorioLogin;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Login>> Get()
        {
            return Ok(_repositorioLogin.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<Login> Get(int id)
        {
            var login = _repositorioLogin.GetById(id);
            if (login == null)
            {
                return NotFound();
            }
            return Ok(login);
        }

        [HttpPost]
        public ActionResult<Login> Post([FromBody] Login login)
        {
            if (login == null)
            {
                return BadRequest();
            }
            _repositorioLogin.Add(login);
            return CreatedAtAction(nameof(Get), new { id = login.Id }, login);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Login login)
        {
            if (login == null || login.Id != id)
            {
                return BadRequest();
            }

            var existingLogin = _repositorioLogin.GetById(id);
            if (existingLogin == null)
            {
                return NotFound();
            }

            _repositorioLogin.Update(login);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var login = _repositorioLogin.GetById(id);
            if (login == null)
            {
                return NotFound();
            }

            _repositorioLogin.Delete(id);
            return NoContent();
        }
    }
}
