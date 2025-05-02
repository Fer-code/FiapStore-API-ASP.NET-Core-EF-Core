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

        //Adcionar livros em massa
        [HttpPost("cadastro-em-massa")]
        public IActionResult CadastroEmMassa()
        {
            try
            {
                var livros = new List<Livro>()
                {
                    new Livro() { Nome = "Livro 1", Editora = "Editora" },
                    new Livro() { Nome = "Livro 2", Editora = "Editora" },
                    new Livro() { Nome = "Livro 3", Editora = "Editora" },
                    new Livro() { Nome = "Livro 4", Editora = "Editora" },
                    new Livro() { Nome = "Livro 5", Editora = "Editora" },
                    new Livro() { Nome = "Livro 6", Editora = "Editora" },
                    new Livro() { Nome = "Livro 7", Editora = "Editora" },
                    new Livro() { Nome = "Livro 8", Editora = "Editora" },
                    new Livro() { Nome = "Livro 9", Editora = "Editora" },
                    new Livro() { Nome = "Livro 10", Editora = "Editora" },
                };

                _livroRepository.CadastrarEmMassa(livros);
                return Ok();
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}
