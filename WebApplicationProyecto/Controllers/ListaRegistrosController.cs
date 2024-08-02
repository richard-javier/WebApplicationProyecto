using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using WebApplicationBackend.Entidades;
using WebApplicationBackend.Repositorio;

namespace WebApplicationBackend.Controllers
{
    [Route("api/listaregistros")]
    [ApiController]
    public class ListaRegistrosController : ControllerBase
    {
        private readonly IRepositorioListaRegistros _repositorioListaRegistros;

        public ListaRegistrosController(IRepositorioListaRegistros repositorioListaRegistros)
        {
            _repositorioListaRegistros = repositorioListaRegistros;
        }

        [HttpGet]
        public ActionResult<IEnumerable<ListaRegistros>> Get()
        {
            return Ok(_repositorioListaRegistros.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<ListaRegistros> Get(int id)
        {
            var listaRegistros = _repositorioListaRegistros.GetById(id);
            if (listaRegistros == null)
            {
                return NotFound();
            }
            return Ok(listaRegistros);
        }

        [HttpPost]
        public ActionResult<ListaRegistros> Post([FromBody] ListaRegistros listaRegistros)
        {
            if (listaRegistros == null)
            {
                return BadRequest();
            }
            _repositorioListaRegistros.Add(listaRegistros);
            return CreatedAtAction(nameof(Get), new { id = listaRegistros.Id }, listaRegistros);
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] ListaRegistros listaRegistros)
        {
            if (listaRegistros == null || listaRegistros.Id != id)
            {
                return BadRequest();
            }

            var existingListaRegistros = _repositorioListaRegistros.GetById(id);
            if (existingListaRegistros == null)
            {
                return NotFound();
            }

            _repositorioListaRegistros.Update(listaRegistros);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var listaRegistros = _repositorioListaRegistros.GetById(id);
            if (listaRegistros == null)
            {
                return NotFound();
            }

            _repositorioListaRegistros.Delete(id);
            return NoContent();
        }
    }
}
