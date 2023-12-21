using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Diagnostics.Metrics;
using Veiculos.API.Data;
using Veiculos.API.Extensions;
using Veiculos.API.Models.Request;
using Veiculos.API.Models.Response;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Veiculos.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FabricanteController : ControllerBase
    {
        private readonly DbVeiculos _dbContext;

        public FabricanteController( DbVeiculos ctx)
        {
            _dbContext = ctx;
        }


        // GET: api/<FabricanteController>
        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<FabricanteResponse> result;
            result = _dbContext.Fabricantes.Select(fabricante => fabricante.Map());
            return Ok(result);
        }

        // GET api/<FabricanteController>/5
        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var fabricante = _dbContext.Fabricantes.Where(fabricante => fabricante.Id == id).FirstOrDefault();

            if (fabricante is null)
                return NotFound("Registro não encontrado");

            var result = fabricante.Map();

            return Ok(result);
        }

        // POST api/<FabricanteController>
        [HttpPost]
        public IActionResult CriarFabricante([FromBody] FabricanteRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());


                var fabricante = request.Map();
                _dbContext.Fabricantes.Add(fabricante);
                _dbContext.SaveChanges();

                return Created(uri: string.Empty, new { id = fabricante.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Fabricante_Nome"))
                    return BadRequest(new { Chave = "Nome", Valor = "Nome duplicado" });
                return StatusCode(500, $"Falha na atualização do fabricante => {ex.GetBaseException().Message}");
            }

        }

        // PUT api/<FabricanteController>/5
        [HttpPut("{id:guid}")]
        public IActionResult Put([FromRoute]Guid id, [FromBody]FabricanteRequest request )
        {
            try
            {

                var fabricante = _dbContext.Fabricantes.FirstOrDefault(fabricante => fabricante.Id == id);
                if (fabricante is null)
                    return NotFound("registro não ecncomtrado");

                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                fabricante.Nome = request.Nome.ToUpper();

                _dbContext.SaveChanges();

                return NoContent();

            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Fabricante_Nome"))
                    return BadRequest(new { Chave = "Nome", Valor = "Nome duplicado" });
                return StatusCode(500, $"Falha na atualização do fabricante => {ex.GetBaseException().Message}");
            }

        }

        // DELETE api/<FabricanteController>/5
        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var fabricante = _dbContext.Fabricantes.Where(fabricante => fabricante.Id == id).FirstOrDefault();
            if (fabricante is null)
                return NotFound("registro não encontrado");

            _dbContext.Fabricantes.Remove(fabricante);
            _dbContext.SaveChanges();

            return NoContent();



        }
    }
}
