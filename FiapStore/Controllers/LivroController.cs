using Core.Entity;
using Core.Input;
using Core.Repository;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;

namespace FiapStoreAPI.Controllers
{
    [ApiController]
    [Route("/[controller]")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        public LivroController(ILivroRepository livroRepository) { 
            _livroRepository = livroRepository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_livroRepository.ObterTodos());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Get([FromRoute] int id)
        {
            try
            {
                return Ok(_livroRepository.ObterPorId(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] LivroInput input)
        {
            try
            {
                var livro = new Livro()
                {
                    Nome = input.Nome,
                    Editora = input.Editora
                };
                _livroRepository.Cadastrar(livro);
                return Ok();
            }
            catch (Exception ex) { 
                return BadRequest(ex.Message);
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] LivroUpdateInput input) {
            try
            {
                var livro = _livroRepository.ObterPorId(input.Id);
                livro.Nome = input.Nome;
                livro.Editora = input.Editora;
                _livroRepository.Alterar(livro);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id) {
            try
            {
                _livroRepository.Deletar(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
