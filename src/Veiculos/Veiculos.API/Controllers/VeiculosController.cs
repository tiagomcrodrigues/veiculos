using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using Veiculos.API.Data;
using Veiculos.API.Extensions;
using Veiculos.API.Models.Request;
using Veiculos.API.Models.Response;

namespace Veiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VeiculosController : ControllerBase
    {

        private readonly DbContext _dbContext = new();


        [HttpGet("{id:guid}")]
        public IActionResult ObterPeloId([FromRoute] Guid id)
        {

            var veiculo = _dbContext.Veiculos.Where(veiculo => veiculo.Id == id).FirstOrDefault();

            if (veiculo == null)
                return NotFound("Registro não encontrado");

            var result = veiculo.Map();

            return Ok(result);
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string? fabricante)
        {


            IEnumerable<VeiculoResponse> result;

            if (string.IsNullOrWhiteSpace(fabricante))
            {
                result = _dbContext.Veiculos.Select(veiculo => veiculo.Map());
            }
            else
            {
                result = _dbContext.Veiculos.Where(veiculo => veiculo.Fabricante == fabricante).Select(s => s.Map());
            }

            return Ok(result);
        }

        [HttpPost]
        public IActionResult CriarVeiculo([FromBody] VeiculoRequest request)
        {

            if (!ModelState.IsValid)
            {
                var criticas = ModelState
                    .Select(s => new 
                    { 
                        Chave = s.Key, 
                        Valor = string.Join(',', s.Value
                        .Errors
                        .Select(s => s.ErrorMessage))
                    });
                return BadRequest(criticas);
            }

            // Mapear request para Entidade de Bancos
            var veiculo = request.Map();
            _dbContext.Veiculos.Add(veiculo);

            return Created(uri: veiculo.Id.ToString(), null);

        }

        [HttpDelete("{id:guid}")]
        public IActionResult Excluir([FromRoute]Guid id)
        {
            var veiculo = _dbContext.Veiculos.Where(veiculo => veiculo.Id == id ).FirstOrDefault();
            if (veiculo == null)
                return NotFound("registro não encotrado");

            _dbContext.Veiculos.Remove(veiculo);

            return NoContent();
        }










    }
}
