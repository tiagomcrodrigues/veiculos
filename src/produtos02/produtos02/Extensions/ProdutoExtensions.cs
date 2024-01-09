using produtos02.Data.Entities;
using produtos02.Models.Request;
using produtos02.Models.Response;

namespace produtos02.Extensions
{
    public static class ProdutoExtensions
    {


        public static Produto Map(this ProdutoRequest request)
        {
            Produto produto = new()
            {
                Nome = request.Nome ?? string.Empty,
                Descricao = (request.Descricao ?? string.Empty).ToUpper(),
                CategoriaId = request.CategoriaId,
                Ativo = request.Ativo
            };
            return produto;
        }

        public static ProdutoResponse Map(this Produto entidade)
        {
            var produto = new ProdutoResponse()
            {
                Id = entidade.Id,
                Nome = entidade.Nome ?? string.Empty,
                Descricao = (entidade.Descricao ?? string.Empty).ToUpper(),
                Quantidade = entidade.Estoque?.Quantidade ?? 0,
                CustoMedio = entidade.Estoque?.CustoMedio ?? 0,
                preco = entidade.Precos?.OrderByDescending(o => o.DataCadastro).FirstOrDefault()?.Valor ?? 0.00 ,
                Categoria = new()
                {
                    Id = entidade.CategoriaId,
                    Descricao = entidade.Categoria.Descricao
                },
                Ativo = entidade.Ativo
            };
            return produto;
        }

    }


}
