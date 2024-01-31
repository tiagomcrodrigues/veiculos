using Livraria.Data.Entities;
using Livraria.Extensions;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Livraria.Tools;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PessoasController : Controller
    {
        private readonly DbLivraria _dbLivraria;

        public PessoasController(DbLivraria ctx)
        {
            _dbLivraria = ctx;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<PessoasResponse> result = _dbLivraria.Pessoas
                                            .Select(pessoas => pessoas.Map(Ferramentas.BuscaCep(pessoas.Cep).Result));

            return Ok(result);
        }
      
        [HttpPost]
        public IActionResult Criar([FromBody] PessoasRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

               Pessoas pessoas =  request.Map();
                _dbLivraria.Pessoas.Add(pessoas);
                _dbLivraria.SaveChanges();
                return Created(uri: string.Empty, new { id = pessoas.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Pessoas_Pessoas.Nome"))
                    return BadRequest(new { Chave = "Pessoa", valor = "Pessos Duplicado" });
                return StatusCode(500, $"Falha na criação de pessoa => {ex.GetBaseException().Message}");
            }



        }

        [HttpGet("{id:int}")]
        public IActionResult ListarId([FromRoute] int id)
        {
            var pessoa = _dbLivraria.Pessoas.Where(pessoa => pessoa.Id == id).FirstOrDefault();

            if (pessoa == null)
                return NotFound("Pessoa não encontrada");

            var resut = pessoa.Map(Ferramentas.BuscaCep(pessoa.Cep).Result);
            return Ok(resut);
        }

        [HttpPut("{id:int}")]
        public IActionResult Editar([FromRoute] int id, [FromBody] PessoasRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

                var pessoa = _dbLivraria.Pessoas.Where(pessoa => pessoa.Id == id).FirstOrDefault();
                if (pessoa == null)
                    return NotFound("Pessoa não encontrada");

                pessoa.Nome = request.Nome;
                pessoa.Cpf = request.Cpf;
                pessoa.Cep = request.Cep;
                pessoa.Numero = request.Numero;
                pessoa.Complemento = request.Complemento;
                pessoa.Telefone = request.Telefone;

                _dbLivraria.SaveChanges();
                return NoContent();
            }
            catch (Exception ex)
            {

                if (ex.GetBaseException().Message.Contains("UK_Pessoas_Pessoas.Nome"))
                    return BadRequest(new { Chave = "Pessoa", valor = "Pessos Duplicado" });
                return StatusCode(500, $"Falha na Edição de pessoa => {ex.GetBaseException().Message}");
            }


        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {

            var pessoa = _dbLivraria.Pessoas.Where(pessoa => pessoa.Id == id).FirstOrDefault();
            if (pessoa == null)
                return NotFound("Pessoa não encontrada");
            
            _dbLivraria.Pessoas.Remove(pessoa);
            _dbLivraria.SaveChanges();
            return NoContent();
        }
    }
}
