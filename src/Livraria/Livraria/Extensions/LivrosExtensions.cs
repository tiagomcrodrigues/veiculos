using Livraria.Data.Entities;
using Livraria.Models.Request;
using Livraria.Models.Response;

namespace Livraria.Extensions
{
    public static class LivrosExtensions
    {
        public static Livros Map(this LivrosRequest request)
        {
            Livros livros = new()
            {
                Titulo = request.Titulo.ToUpper(),
                Descricao = request.Descricao.ToUpper(),
                AutorId = request.AutorId,
                Quantidade  = request.Quantidade,
                PermitirEmprestimo = request.PremitirEmprestimo
            };
            return livros;
        }
        public static LivrosResponse Map(this Livros request)
        {
            var livros = new LivrosResponse()
            {
                Id = request.Id,
                Titulo = request.Titulo.ToUpper(),
                Descricao = request.Descricao.ToUpper(),
                AutorId = request.AutorId,
                Quantidade = request.Quantidade,
                PremitirEmprestimo = request.PermitirEmprestimo
            };
            return livros;

        }
    }
}
