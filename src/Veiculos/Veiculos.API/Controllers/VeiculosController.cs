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

            if (veiculo is null)
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
                /// para buscar outros tipos de campos
                result = _dbContext.Veiculos.Where(veiculo => 
                    veiculo.Fabricante
                        .Equals(fabricante,StringComparison.OrdinalIgnoreCase))
                        .Select(s => s.Map());
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

            return Created(uri: string.Empty, new {id=veiculo.Id.ToString()});

        }

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute]Guid id,[FromBody]VeiculoRequest request)
        {
            ///jeito avancado de buscar ID
            var veiculo = _dbContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo is null)
                return NotFound("registro não encontrado");

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
                return BadRequest();
            }
            veiculo.AnoModelo = request.AnoModelo.Value;
            veiculo.AnoFabricacao = request.AnoFabricacao.Value;
            veiculo.Modelo = request.Modelo;
            veiculo.Fabricante = request.Fabricante;
            veiculo.Cor = request.Cor;
            veiculo.Placa = request.Placa;
            veiculo.Tipo = request.Tipo;

            return NoContent();


        }

        [HttpPatch("{id:guid}")]
        public IActionResult EditarParcial([FromRoute] Guid id, [FromBody] VeiculoPatchRequest request)
        {

            if (request is null)
<<<<<<< HEAD
                return BadRequest("Corpo da requisição inválida ou não informada");
=======
                return BadRequest("Corpo da requisição inválida");
>>>>>>> 0c73b0bf44bd328c0ac3c314439c66eaf8edb60c

            ///jeito avancado de buscar ID
            var veiculo = _dbContext.Veiculos.FirstOrDefault(veiculo => veiculo.Id == id);
            if (veiculo is null)
                return NotFound("registro não encontrado");

            // Tem valor e é diferente do que está gravado
            if (request.AnoModelo.HasValue && request.AnoModelo != veiculo.AnoModelo)
                veiculo.AnoModelo = request.AnoModelo.Value;

            if (request.AnoFabricacao.HasValue && request.AnoFabricacao != veiculo.AnoFabricacao) { 
                 veiculo.AnoFabricacao = request.AnoFabricacao.Value; }

            if (request.Modelo is not null && request.Modelo != veiculo.Modelo)  
             veiculo.Modelo = request.Modelo; 

            if (request.Fabricante is not null && request.Fabricante != veiculo.Fabricante) 
             veiculo.Fabricante = request.Fabricante; 

            if (request.Cor is not null && request.Cor != veiculo.Cor)
            veiculo.Cor = request.Cor;

            if (request.Placa is not null && request.Placa != veiculo.Placa)
             veiculo.Placa = request.Placa; 

            if (request.Tipo is not null && request.Tipo != veiculo.Tipo) 
             veiculo.Tipo = request.Tipo;

            return NoContent();


        }







        [HttpDelete("{id:guid}")]
        public IActionResult Excluir([FromRoute]Guid id)
        {
            ///jeito basico de buscar ID
            var veiculo = _dbContext.Veiculos.Where(veiculo => veiculo.Id == id ).FirstOrDefault();
            if (veiculo is null)
                return NotFound("registro não encotrado");

            _dbContext.Veiculos.Remove(veiculo);

            return NoContent();
        }










    }
}
