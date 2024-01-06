using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using produtos02.Data.Entities;
using produtos02.Extensions;
using produtos02.Models.Request;
using produtos02.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace produtos02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DbProduto _DbProduto;

        public CategoriaController(DbProduto ctx)
        {
            _DbProduto = ctx;
        }


        [HttpGet]
        public IActionResult Listar([FromQuery] int? ordem = 1)
        {
            IEnumerable<CategoriaResponse> result = _DbProduto.Categorias
                .Select(categoria => categoria.Map());

            if (ordem == 1)
                result = result.OrderBy(categoria => categoria.Descricao);
            else
                result = result.OrderByDescending(Categoria => Categoria.Descricao );

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult ListarID([FromRoute] Guid id)
        {
            var categoria = _DbProduto.Categorias.Where(categoria => categoria.Id == id).FirstOrDefault();

            if (categoria is null)
                return NotFound("Categoria não encontrada");

            var result = categoria.Map();

            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                Categoria categoria = request.Map();
                _DbProduto.Categorias.Add(categoria);
                _DbProduto.SaveChanges();
                return Created(uri: string.Empty, new { id = categoria.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Categoria_Categoria.Descricao"))
                    return BadRequest(new { Chave = "Descricao", Valor = "Descricao duplicado" });
                return StatusCode(500, $"Falha na Criação do Categoria => {ex.GetBaseException().Message}");
            }


        }

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute] Guid id, [FromBody] CategoriaRequest request)
        {
            var categoria = _DbProduto.Categorias.Where(categoria => categoria.Id == id).FirstOrDefault();

            try
            {

                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                if (categoria is null)
                    return NotFound("Categoria não encontrada");

                categoria.Descricao = request.Descricao;
                categoria.Ativo = request.Ativo;

                _DbProduto.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Categoria_Categoria.Descricao"))
                    return BadRequest(new { Chave = "Descricao", Valor = "Descricao duplicado" });
                return StatusCode(500, $"Falha na Edição do Categoria => {ex.GetBaseException().Message}");
            }

        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _DbProduto.Categorias.Where(categoria => categoria.Id == id).FirstOrDefault();
            if (categoria is null)
            {
                return NotFound("categoria não encontrada ");
            }
            else
            {
                try
                {
                    _DbProduto.Categorias.Remove(categoria);
                    _DbProduto.SaveChanges();
                    return NoContent();
                }
                catch (Exception ex)
                {
                    return BadRequest(new { Chave = "Categoria", Valor = "Esta em uso não pode ser deletada" });
                }

            }




        }
    }
}
