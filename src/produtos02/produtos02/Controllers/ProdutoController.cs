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
    public class ProdutoController : ControllerBase
    {

        private readonly DbProduto _dbProduto;

        public ProdutoController(DbProduto ctx)
        {
            _dbProduto = ctx;
        }

        [HttpGet]
        public IActionResult Listar([FromQuery] string? categoria, [FromQuery] int? ordem = 1)
        {
            IEnumerable<ProdutoResponse> result;

            if (string.IsNullOrWhiteSpace(categoria) )
            {
                result = _dbProduto
                    .Produtos
                    .ToList()
                    .Select(produto => produto.Map());
            }
            else
            {
                result = _dbProduto
                    .Produtos
                    .Where(produto => produto.Categoria.Descricao == categoria)
                    .ToList()
                    .Select(s => s.Map());
            }

            if (ordem == 1)
                result = result.OrderBy(produto => produto.Nome);
            else
                result = result.OrderByDescending(produto => produto.Nome);

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult Get([FromRoute] Guid id)
        {
            var produto = _dbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado");

            var result = produto.Map();

            return Ok(result);
        }

        //TODO : tratar erro quando colocar  mesmo nome e id categoria  errado

        [HttpPost]
        public IActionResult Post([FromBody] ProdutoRequest request)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState.CapturaCriticas());

                var categoria = _dbProduto.Categorias.Where(categoria => categoria.Id == request.CategoriaId).FirstOrDefault();
               
                if (categoria is null)
                {
                    return NotFound("Categoria não encontrado");
                }

                Produto produto = request.Map();
                _dbProduto.Produtos.Add(produto);
                _dbProduto.SaveChanges();

                return Created(uri: string.Empty, new { id = produto.Id.ToString() });
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Produto_Produto.Nome"))
                    return BadRequest(new { Chave = "Produto", Valor = "Produto duplicado" });
                return StatusCode(500, $"Falha na Criação do Produto => {ex.GetBaseException().Message}");
            }
        }

        //TODO : tratar erro quando colocar  mesmo nome e linha 45

        [HttpPut("{id:guid}")]
        public IActionResult Editar([FromRoute] Guid id, [FromBody] ProdutoRequest request)
        {
            var produto = _dbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();
            try
            {
                if (produto is null)
                    return NotFound("Produto não encontrado");

                var categoria = _dbProduto.Categorias.Where(categoria => categoria.Id == request.CategoriaId).FirstOrDefault();

                if (categoria is null)
                {
                    return NotFound("Categoria não encontrado");
                }

                produto.Nome = request.Nome;
                produto.Descricao = request.Descricao;
                produto.CategoriaId = request.CategoriaId;
                produto.Ativo = request.Ativo;

                _dbProduto.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                if (ex.GetBaseException().Message.Contains("UK_Produto_Produto.Nome"))
                    return BadRequest(new { Chave = "Produto", Valor = "Produto duplicado" });
                return StatusCode(500, $"Falha na Edição do Produto => {ex.GetBaseException().Message}");
            }

        }

        [HttpPost("{ProdutoId:guid}/preco")]
        public IActionResult PrecoCadastro([FromRoute] Guid produtoId, [FromBody] ProdutoPrecoRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.CapturaCriticas()); }
            try
            {
                var produto = _dbProduto.Produtos.Where(produto => produto.Id == produtoId).FirstOrDefault();

                if (produto is null)
                    return NotFound("Produto não encontrado.");

                ProdutoPreco preco =  new(produtoId,request.Valor);
                
                _dbProduto.Precos.Add(preco);
                _dbProduto.SaveChanges();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Falha na entrada do estoque => {ex.GetBaseException().Message}");
            }


        }

        [HttpPatch("{produtoId:guid}/entrada-estoque")]
        public IActionResult EntradaEstoque([FromRoute] Guid produtoId, [FromBody] EstoqueRequest request)
        {
            if (!ModelState.IsValid) { return BadRequest(ModelState.CapturaCriticas()); }
            try
            {
                var produto = _dbProduto.Produtos.Where(produto => produto.Id == produtoId).FirstOrDefault();
               
                if (produto is null)
                    return NotFound("Produto não encontrado.");

                Estoque estoque = produto.Estoque ?? new Estoque() { ProdutoId = produtoId };

                estoque.CustoMedio =
                    (
                        (estoque.Quantidade * estoque.CustoMedio)
                        + (request.Quantidade * request.Valor)
                    ) / (estoque.Quantidade + request.Quantidade);

                estoque.Quantidade += request.Quantidade;

                if (produto.Estoque is null)
                    _dbProduto.Estoque.Add(estoque);

                _dbProduto.SaveChanges();

                return NoContent();

                /*
                if (produto.Estoque is null)
                {
                    Estoque estoque = new()
                    {
                        ProdutoId = produtoId,
                        Quantidade = request.Quantidade,
                        CustoMedio = request.Valor
                    };

                    _dbProduto.Estoque.Add(estoque);
                    _dbProduto.SaveChanges();
                    
                    return Created(uri: string.Empty, new { id = produto.Id.ToString() });
                }
                else
                {
                    decimal cal = (produto.Estoque.Quantidade * produto.Estoque.CustoMedio) + (request.Quantidade * request.Valor);
                    request.Valor = cal / (produto.Estoque.Quantidade + request.Quantidade);

                    produto.Estoque.Quantidade = request.Quantidade;
                    produto.Estoque.CustoMedio = request.Valor;

                    _dbProduto.SaveChanges();
                    return NoContent();
                }*/
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Falha na entrada do estoque => {ex.GetBaseException().Message}");
            }


        }

        [HttpPatch("{ProdutoId:guid}/saida-estoque")]
        public IActionResult SaidaEStoque([FromRoute] Guid produtoId, [FromBody] EstoqueRequestSaida request)
        {
            var produto = _dbProduto.Produtos.Where(produto => produto.Id == produtoId).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado.");

            Estoque estoque = produto.Estoque ?? new Estoque() { ProdutoId = produtoId };

            estoque.Quantidade -= request.Quantidade;

            _dbProduto.SaveChanges();
            return NoContent();

        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete([FromRoute] Guid id)
        {
            var produto = _dbProduto.Produtos.Where(produto => produto.Id == id).FirstOrDefault();

            if (produto is null)
                return NotFound("Produto não encontrado");

            _dbProduto.Produtos.Remove(produto);
            _dbProduto.SaveChanges();

            return NoContent();
        }
    }
}
