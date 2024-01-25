using Livraria.Data.Entities;
using Livraria.Models.Request;
using Livraria.Models.Response;

namespace Livraria.Extensions
{
    public static class PessoasExtensions
    {
        public static Pessoas Map(this PessoasRequest Request)
        {
            Pessoas pessoas = new()
            {
                Nome = Request.Nome.ToUpper(),
                Cpf = Request.Cpf,
                Cep = Request.Cep,
                Numero = Request.Numero,
                Complemento = Request.Complemento.ToUpper(),
                Telefone = Request.Telefone
            };
            return pessoas;
        }

        public static PessoasResponse Map(this Pessoas Response)
        {
            var pessoas = new PessoasResponse()
            {
                Id = Response.Id,
                Nome = Response.Nome.ToUpper(),
                Cpf = Response.Cpf,
                Cep = Response.Cep,
                Numero = Response.Numero,
                Complemento = Response.Complemento.ToUpper(),
                Telefone = Response.Telefone
            };
            return pessoas;
        }
       


    }
}
