using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/forgotpassword")]
    [ApiController]
    public class ForgotPasswordController : ControllerBase
    {
        private readonly IRepositorioForgotPassword _repositorioForgotPassword;

        public ForgotPasswordController(IRepositorioForgotPassword repositorioForgotPassword)
        {
            _repositorioForgotPassword = repositorioForgotPassword;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ForgotPassword>> Get()
        {
            return Ok(_repositorioForgotPassword.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ForgotPassword> Get(int id)
        {
            var forgotPassword = _repositorioForgotPassword.GetById(id);
            if (forgotPassword == null)
            {
                return NotFound();
            }
            return Ok(forgotPassword);
        }

        [HttpPost]
        public ActionResult<ForgotPassword> Post([FromBody] ForgotPassword forgotPassword)
        {
            if (forgotPassword == null)
            {
                return BadRequest();
            }
            _repositorioForgotPassword.Add(forgotPassword);
            return CreatedAtAction(nameof(Get), new { id = forgotPassword.Id }, forgotPassword);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ForgotPassword forgotPassword)
        {
            if (forgotPassword == null || forgotPassword.Id != id)
            {
                return BadRequest();
            }

            var existingForgotPassword = _repositorioForgotPassword.GetById(id);
            if (existingForgotPassword == null)
            {
                return NotFound();
            }

            _repositorioForgotPassword.Update(forgotPassword);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var forgotPassword = _repositorioForgotPassword.GetById(id);
            if (forgotPassword == null)
            {
                return NotFound();
            }

            _repositorioForgotPassword.Delete(id);
            return NoContent();
        }
    }
}
