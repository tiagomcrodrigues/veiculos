using Livraria.Data.Entities;
using Livraria.Models.Request;
using Livraria.Models.Response;

namespace Livraria.Extensions
{
    public static class AutoresExtensions
    {
        public static Autores Map(this AutoresRequest request  )
        {
            Autores autores = new()
            {
                Nome = request.Nome.ToUpper()
            };
            return autores;
        }
        public static AutoresResponse Map(this Autores request ) 
        {
            var autores = new AutoresResponse()
            {
                Id = request.Id,
                Nome = request.Nome.ToUpper()
            };
             return autores;

        }
    }
}
