 using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using produtos02.Data.Entities;
using produtos02.Extensions;
using produtos02.Models.Request;
using produtos02.Models.Responce;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace produtos02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {

        private readonly DbProduto _DbProduto;

        public ProdutoController(DbProduto ctx)
        {
            _DbProduto = ctx;
        }

        [HttpGet]
        public IActionResult Listar()
        {
            IEnumerable<ProdutoResponse> result;
            result = _DbProduto.Produtos.Select(produto => produto.Map());
            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var produto = _DbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado");

            var result = produto.Map();

            return Ok(result);
        }
        
        //TODO : tratar erro quando colocar  mesmo nome e id categoria  errado

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            if(!ModelState.IsValid)
                return BadRequest("Produto não e valida");
           

            Produto produto = request.Map();
            _DbProduto.Produtos.Add(produto);
            _DbProduto.SaveChanges();

            return Created(uri: string.Empty, new { id = produto.Id.ToString() });

        }

        //TODO : tratar erro quando colocar  mesmo nome e linha 45

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute]Guid id, [FromBody] ProdutoRequest request)
        {
            var produto = _DbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado");

            produto.Nome = request.nome;
            produto.Descricao = request.Descricao;
            produto.CategoriaId = request.CategoriaId;
            produto.Ativo = request.Ativo;

            _DbProduto.SaveChanges();


            return NoContent();
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute]Guid id)
        {
            var produto = _DbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado");

            _DbProduto.Produtos.Remove(produto);
            _DbProduto.SaveChanges();

            return NoContent();
        }
    }
}
