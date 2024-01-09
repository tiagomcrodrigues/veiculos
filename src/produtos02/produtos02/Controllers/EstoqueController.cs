using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using produtos02.Data.Entities;
using produtos02.Extensions;
using produtos02.Models.Request;

namespace produtos02.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EstoqueController : ControllerBase
    {
        private readonly DbProduto _dbProduto;
        public EstoqueController(DbProduto ctx)
        {
            _dbProduto = ctx;
        }



        //[HttpPatch("{produtoId:guid}/entrada")]
        //public IActionResult EntradaEstoque([FromRoute] Guid produtoId, [FromBody] EstoqueRequest request)
        //{
        //    if (!ModelState.IsValid) { return BadRequest(ModelState.CapturaCriticas()); }
        //    try
        //    {
        //        var produto = _dbProduto.Produtos.Where(produto => produto.Id == produtoId).FirstOrDefault();
        //        if (produto is null)
        //            return NotFound("Produto não encontrado.");

        //        Estoque estoque = produto.Estoque ?? new Estoque() { ProdutoId = produtoId };
                
        //        estoque.CustoMedio = 
        //            (
        //                (estoque.Quantidade * estoque.CustoMedio) 
        //                + (request.Quantidade * request.Valor)
        //            ) / (estoque.Quantidade + request.Quantidade);

        //        estoque.Quantidade += request.Quantidade;

        //        if (produto.Estoque is null)
        //            _dbProduto.Estoque.Add(estoque);

        //        _dbProduto.SaveChanges();

        //        return NoContent();

        //        /*
        //        if (produto.Estoque is null)
        //        {
        //            Estoque estoque = new()
        //            {
        //                ProdutoId = produtoId,
        //                Quantidade = request.Quantidade,
        //                CustoMedio = request.Valor
        //            };

        //            _dbProduto.Estoque.Add(estoque);
        //            _dbProduto.SaveChanges();
                    
        //            return Created(uri: string.Empty, new { id = produto.Id.ToString() });
        //        }
        //        else
        //        {
        //            decimal cal = (produto.Estoque.Quantidade * produto.Estoque.CustoMedio) + (request.Quantidade * request.Valor);
        //            request.Valor = cal / (produto.Estoque.Quantidade + request.Quantidade);

        //            produto.Estoque.Quantidade = request.Quantidade;
        //            produto.Estoque.CustoMedio = request.Valor;

        //            _dbProduto.SaveChanges();
        //            return NoContent();
        //        }*/
        //    }
        //    catch (Exception ex)
        //    {
        //        return StatusCode(500, $"Falha na entrada do estoque => {ex.GetBaseException().Message}");
        //    }


        //}



    }
}
