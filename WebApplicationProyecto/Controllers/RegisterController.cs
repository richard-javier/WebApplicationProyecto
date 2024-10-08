﻿using Microsoft.AspNetCore.Mvc;
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

            try
            {
                _repositorioRegister.Add(register);
                return Ok(new { message = "Registration successful." });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var users = _repositorioRegister.GetAll();
                return Ok(users);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var user = _repositorioRegister.GetById(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }
                return Ok(user);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public IActionResult Update(int id, [FromBody] Register register)
        {
            if (register == null || id != register.Id)
            {
                return BadRequest("Invalid data.");
            }

            try
            {
                var existingUser = _repositorioRegister.GetById(id);
                if (existingUser == null)
                {
                    return NotFound("User not found.");
                }

                _repositorioRegister.Update(register);
                return Ok("User updated successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var user = _repositorioRegister.GetById(id);
                if (user == null)
                {
                    return NotFound("User not found.");
                }

                _repositorioRegister.Delete(id);
                return Ok("User deleted successfully.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
