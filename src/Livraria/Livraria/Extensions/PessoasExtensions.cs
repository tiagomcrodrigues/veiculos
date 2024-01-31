using Livraria.Data.Entities;
using Livraria.Models.Request;
using Livraria.Models.Response;
using Microsoft.AspNetCore.Http.HttpResults;
using System.Text.Json;
using TesteQuebraTudo;

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

        public static PessoasResponse Map(this Pessoas pessoa, CepResponse endereco)
        {
            
            endereco.Complemento = pessoa.Complemento.ToUpper();
            endereco.Numero = pessoa.Numero;
            var response = new PessoasResponse()
            {
                Id = pessoa.Id,
                Nome = pessoa.Nome.ToUpper(),
                Cpf = pessoa.Cpf,
                Endereco = endereco,
                Telefone = pessoa.Telefone
            };
            return response;
        }

    }
}
