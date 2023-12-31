using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using produtos02.Data.Entities;
using produtos02.Extensions;
using produtos02.Models.Request;
using produtos02.Models.Responce;
using produtos02.Models.Response;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace produtos02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriaController : ControllerBase
    {
        private readonly DbProduto _DbProduto;

        //TODO : tratar erro quando colocar  mesma descrição categoria 

        public CategoriaController(DbProduto ctx)
        {
            _DbProduto = ctx;
        }


        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<CategoriaResponse> result = _DbProduto.Categorias
                .Select(categoria => categoria.Map());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult ListarID([FromRoute]Guid id)
        {
            var categoria = _DbProduto.Categorias.Where(categoria=>categoria.Id == id).FirstOrDefault();
            
            if (categoria is null) 
                return NotFound("Categoria não encontrada");

            var result = categoria.Map();
            
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Post([FromBody] CategoriaRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest("Categoria não e valida");

            Categoria categoria = request.Map();
            _DbProduto.Categorias.Add(categoria);
            _DbProduto.SaveChanges();

            return Created(uri: string.Empty, new { id = categoria.Id.ToString() });
        }

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute]Guid id, [FromBody] CategoriaRequest request)
        {
            var categoria = _DbProduto.Categorias.Where(categoria => categoria.Id == id).FirstOrDefault();

            if (categoria is null)
                return NotFound("Categoria não encomtrada");

            categoria.Descricao = request.Descricao;
            categoria.Ativo = request.Ativo;

            _DbProduto.SaveChanges();

            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id)
        {
            var categoria = _DbProduto.Categorias.Where(categoria => categoria.Id == id).FirstOrDefault();
            if (categoria is null)
                return NotFound("categoria não encontrada ");

            _DbProduto.Categorias.Remove(categoria);
            _DbProduto.SaveChanges();


            return NoContent();
        }
    }
}
