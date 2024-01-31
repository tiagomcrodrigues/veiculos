using Livraria.Data.Entities;
using Livraria.Extensions;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrosController : Controller
    {
        private readonly DbLivraria _dbLivraria;

        public LivrosController(DbLivraria ctx)
        {
            _dbLivraria = ctx;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<LivrosResponse> result = _dbLivraria.Livros
                                .Select(livros => livros.Map());

            return Ok(result);
        }
        
        [HttpPost]
        public IActionResult Criar([FromBody] LivrosRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

                Livros livros = request.Map();
                _dbLivraria.Livros.Add(livros);
                _dbLivraria.SaveChanges();
                return Created(uri: string.Empty, new { id = livros.Id.ToString() });


            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("Uk_Livros_Livors.Titulo"))
                    return BadRequest(new { Chave = "Livro", valor = "Livro Duplicado" });
                return StatusCode(500, $"Falha na criação de livro => {ex.GetBaseException().Message}");
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult ListarId([FromRoute] int id )
        {
            var livro = _dbLivraria.Livros.Where(livro => livro.Id == id).FirstOrDefault();

            if (livro == null)
                return NotFound("Livro não encontrado");

            var resut = livro.Map();
            return Ok(resut);

        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] LivrosRequest request )
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                var livro = _dbLivraria.Livros.Where(livro => livro.Id == id).FirstOrDefault();
                if (livro == null)
                    return NotFound("Livro não encontrado");

                livro.Titulo = request.Titulo;
                livro.Descricao = request.Descricao;
                livro.AutorId = request.AutorId;
                livro.Quantidade = request.Quantidade;
                livro.PermitirEmprestimo = request.PremitirEmprestimo;

                _dbLivraria.SaveChanges();
                return NoContent();

            }
            catch (Exception ex )
            {
                if (ex.GetBaseException().Message.Contains("Uk_Livros_Livors.Titulo"))
                    return BadRequest(new { Chave = "Livro", valor = "Livro Duplicado" });
                return StatusCode(500, $"Falha na criação de livro => {ex.GetBaseException().Message}");
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult Deletar([FromRoute] int id)
        {
            var livro = _dbLivraria.Livros.Where(livro =>livro.Id == id).FirstOrDefault(); 
            if (livro == null)
                return NotFound("Livro não encontrado");

            _dbLivraria.Livros.Remove(livro);
            _dbLivraria.SaveChanges();
            return NoContent();
        }

    }
}
