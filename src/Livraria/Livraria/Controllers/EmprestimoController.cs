using Livraria.Data.Entities;
using Livraria.Extensions;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmprestimoController : Controller
    {
        private readonly DbLivraria _dbLivraria;

        public EmprestimoController(DbLivraria ctx)
        {
            _dbLivraria = ctx;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<EmprestimoResponse> result = _dbLivraria.Emprestimos
                                .Select(livros => livros.Map());

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Criar([FromBody] EmprestimoRequest request)
        {
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

                var pessoa = _dbLivraria.Pessoas.Where(pessoa => pessoa.Id == request.PessoaId).FirstOrDefault();
                if (pessoa == null)
                    return NotFound("Pessoa não encontrada");

                var livro = _dbLivraria.Livros.Where(livro => livro.Id == request.LivroId).FirstOrDefault();
                if (livro == null)
                    return NotFound("Livro não encontrado");

                Emprestimos emprestimos = request.Map();
                _dbLivraria.Emprestimos.Add(emprestimos);
                _dbLivraria.SaveChanges();
                return Created(uri: string.Empty, new { id = emprestimos.Id.ToString() });

            }

        }

        [HttpPut("{id:int}")]
        public IActionResult Devolucao(int id, [FromBody] EmprestimoDevolucaoRequest  request)
        {
            if(!ModelState.IsValid)
                return BadRequest(ModelState.CapturaCriticas());
             
            var emprestimo = _dbLivraria.Emprestimos.Where(emprestim => emprestim.Id == id).FirstOrDefault();
            if (emprestimo == null)
                return NotFound("Emprestimo não encontrado");

            emprestimo.DataDevolucao = request.DataDevolucao;

            _dbLivraria.SaveChanges();
            return NoContent();

        }


        /*
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
        // PUT api/<EmprestimoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmprestimoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/

    }
}
