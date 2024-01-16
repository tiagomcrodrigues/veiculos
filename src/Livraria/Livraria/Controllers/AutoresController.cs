using Livraria.Data.Entities;
using Livraria.Extensions;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly DbLivraria _dbLivraria;

        public AutoresController(DbLivraria ctx)
        {
            _dbLivraria = ctx;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<AutoresResponse> result = _dbLivraria.Autores
                            .Select(autores => autores.Map());

            return Ok(result);
        }

        [HttpPost]
        public IActionResult criar([FromBody] AutoresRequest request)
        {
            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

                Autores autores = request.Map();
                _dbLivraria.Autores.Add(autores);
                _dbLivraria.SaveChanges();
                return Created(uri: string.Empty, new { id = autores.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Autor_Autor.Nome"))
                    return BadRequest(new { Chave = "Autor", Valor = "Autor duplicado" });
                return StatusCode(500, $"Falha na Criação do Autor => {ex.GetBaseException().Message}");
            }

        }

        [HttpGet("{id:int}")]
        public IActionResult ListarId([FromRoute] int id)
        {
            var autor = _dbLivraria.Autores.Where(autor => autor.Id == id).FirstOrDefault();

            if (autor == null)
                return NotFound("Autor não encontredo");

            var result = autor.Map();
            return Ok(result);
        }

        [HttpPut("{id:int}")]
        public IActionResult Edit([FromRoute] int id, [FromBody] AutoresRequest request)
        {

            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas);

                var autor = _dbLivraria.Autores.Where(autor => autor.Id == id).FirstOrDefault();
                if (autor == null)
                    return NotFound("Autor não encontredo");

                autor.Nome = request.Nome;

                _dbLivraria.SaveChanges();
                return NoContent();

            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Autor_Autor.Nome"))
                    return BadRequest(new { Chave = "Autor", Valor = "Autor duplicado" });
                return StatusCode(500, $"Falha na Criação do Autor => {ex.GetBaseException().Message}");
            }


        }


        [HttpDelete("{id:int}")]
        public IActionResult Delete([FromRoute] int id)
        {
            var autor = _dbLivraria.Autores.Where(autores => autores.Id == id).FirstOrDefault();
            if (autor is null)
                return NotFound("Autor não encontrado");

            _dbLivraria.Autores.Remove(autor);
            _dbLivraria.SaveChanges();
            return NoContent();


        }


    }
}
