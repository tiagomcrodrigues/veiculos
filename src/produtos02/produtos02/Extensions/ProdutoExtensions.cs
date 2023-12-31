using produtos02.Data.Entities;
using produtos02.Models.Request;
using produtos02.Models.Responce;
using produtos02.Models.Response;

namespace produtos02.Extensions
{
    public static class ProdutoExtensions
    {
        public static Produto Map(this ProdutoRequest request)
        {
            Produto produto = new()
            {
                Nome = request.nome ?? string.Empty,
                Descricao = request.Descricao ?? string.Empty,
                CategoriaId = request.CategoriaId,
                Ativo = request.Ativo
            };
            return produto;
        }

        public static ProdutoResponse Map(this Produto response)
        {
            var produto = new ProdutoResponse()
            {
                Id = response.Id,
                Nome = response.Nome ?? string.Empty,
                Descricao = response.Descricao ?? string.Empty,
                CategoriaId = response.CategoriaId,
                Ativo = response.Ativo
            };
            return produto;
        }

    }


}
