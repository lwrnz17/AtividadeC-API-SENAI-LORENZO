
using Exo.WebApi.Models;
using Exo.WebApi.Repositories;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace Exo.WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProjetosController : ControllerBase
    {
        private readonly ProjetoRepository _repositorio;

        public ProjetosController(ProjetoRepository repositorio)
        {
            _repositorio = repositorio;
        }

        // GET: api/Projetos
        [HttpGet]
        public ActionResult<List<Projeto>> Listar()
        {
            return Ok(_repositorio.Listar());
        }

        // GET: api/Projetos/1
        [HttpGet("{id}")]
        public ActionResult<Projeto> BuscarPorId(int id)
        {
            var projeto = _repositorio.BuscarPorId(id);

            if (projeto == null)
                return NotFound();

            return Ok(projeto);
        }

        // POST: api/Projetos
        [HttpPost]
        public IActionResult Cadastrar([FromBody] Projeto projeto)
        {
            _repositorio.Cadastrar(projeto);

            return CreatedAtAction(
                nameof(BuscarPorId),
                new { id = projeto.Id },
                projeto
            );
        }

        // PUT: api/Projetos/1
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, [FromBody] Projeto projeto)
        {
            bool atualizado = _repositorio.Atualizar(id, projeto);

            if (!atualizado)
                return NotFound();

            return NoContent();
        }

        // DELETE: api/Projetos/1
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            bool excluido = _repositorio.Deletar(id);

            if (!excluido)
                return NotFound();

            return NoContent();
        }
    }
}
