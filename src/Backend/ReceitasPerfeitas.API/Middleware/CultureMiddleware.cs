using System.Globalization;
using static System.Net.Mime.MediaTypeNames;

namespace ReceitasPerfeitas.API.Middleware
{
    public class CultureMiddleware
    {
        private readonly RequestDelegate _next;
        public CultureMiddleware(RequestDelegate next)
        {
            _next = next ;        
        }
        public async Task Invoke(HttpContext context)
        {
            // Pegando a lista das linguagens que o .NET dá suporte
            var supportedLanguages = CultureInfo.GetCultures(CultureTypes.AllCultures);

            // Pegando o valor do idioma da requisição
            var requestedCulture = context.Request.Headers["Accept-Language"]
                .FirstOrDefault()?
                .Split(',')[0] // Pega o primeiro idioma da lista
                .Split(';')[0]; // Remove qualquer prioridade (q=0.9)

            // Definindo o idioma padrão como inglês
            var currentCulture = new CultureInfo("en");

            // Verificando se o idioma solicitado é suportado
            if (!string.IsNullOrWhiteSpace(requestedCulture) &&
                supportedLanguages.Any(c => c.Name.Equals(requestedCulture, StringComparison.OrdinalIgnoreCase)))
            {
                currentCulture = new CultureInfo(requestedCulture);
            }

            CultureInfo.CurrentCulture = currentCulture;
            CultureInfo.CurrentUICulture = currentCulture;

            await _next(context);

        }
    }
}
