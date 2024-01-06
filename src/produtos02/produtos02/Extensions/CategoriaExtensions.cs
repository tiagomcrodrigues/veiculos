using produtos02.Data.Entities;
using produtos02.Models.Request;
using produtos02.Models.Response;

namespace produtos02.Extensions
{
    public static class CategoriaExtensions
    {
        public static Categoria Map(this CategoriaRequest request)
        {
            Categoria categoria = new()
            {
                Descricao = request.Descricao.ToUpper(),
                Ativo = request.Ativo
            };
            return categoria;
        }

        public static CategoriaResponse Map(this Categoria response)
        {
            var categoria = new CategoriaResponse()
            {
                Id = response.Id,
                Descricao = response.Descricao.ToUpper(),
                Ativo = response.Ativo
            };
            return categoria;
        }

    }
}
