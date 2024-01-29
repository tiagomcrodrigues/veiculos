using Livraria.Data.Entities;
using Livraria.Models.Request;
using Livraria.Models.Response;

namespace Livraria.Extensions
{
    public static class EmprestimoExtensions
    {
        public static Emprestimos Map(this EmprestimoRequest request)
        {
            Emprestimos emprestimos = new()
            {
                PessoaId = request.PessoaId,
                LivroId = request.LivroId,
                DataDevolucao = Convert.ToDateTime(null)
            };
            return emprestimos;
        }
        /*public static Emprestimos Map(this EmprestimoDevolucaoRequest request)
        {
            Emprestimos emprestimos = new()
            {
                Id = request.Id,
                DataDevolucao = request.DataDevolucao
            };
            return emprestimos;
        }*/

        public static EmprestimoResponse Map(this Emprestimos request)
        {
            var emprestimos = new EmprestimoResponse()
            {
                Id = request.Id,
                PessoaId = request.PessoaId,
                LivroId = request.LivroId,
                DataEprestimo = request.DataEprestimo,
                DataVencimeto = request.DataVencimeto,
                DataDevolucao = request.DataDevolucao
            };
            return emprestimos;
        }



    }
}
