using Microsoft.AspNetCore.Mvc.ModelBinding;

namespace produtos02.Extensions
{
    public static class ToolsExtensions
    {
        public static object CapturaCriticas(this ModelStateDictionary modelState)
        {
            var criticas = modelState
                    .Select(s => new
                    {
                        Chave = s.Key,
                        Valor = string.Join(',', s.Value
                            .Errors
                            .Select(s => s.ErrorMessage))
                    });
            return criticas;

        }


    }
}
