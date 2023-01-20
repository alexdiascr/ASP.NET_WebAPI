using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Security.Claims;

namespace DevIO.Api.Extensions
{
    public class CustomAuthorization
    {
        //O método recebe o contexto da requisição, Nome da claime, valor da claime
        public static bool ValidarClaimsUsuario(HttpContext context, string claimName, string claimValue)
        {
            //1° Verificar se o usário realmente está autenticado
            //2° Verificar se o usuário possui alguma claime onde o nome
            //da claime que tá sendo exigido contem o valor que tá sendo exigido
            return context.User.Identity.IsAuthenticated &&
                   context.User.Claims.Any(c => c.Type == claimName && c.Value.Contains(claimValue));
        }
    }

    public class ClaimsAuthorizeAttribute : TypeFilterAttribute
    {
        public ClaimsAuthorizeAttribute(string claimName, string claimValue) : base(typeof(RequisitoClaimFilter))
        {
            Arguments = new object[] { new Claim(claimName, claimValue) };
        }
    }

    public class RequisitoClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequisitoClaimFilter(Claim claim)
        {
            _claim = claim;
        }


        public void OnAuthorization(AuthorizationFilterContext context)
        {
            //Verificar se está autenticado 
            if (!context.HttpContext.User.Identity.IsAuthenticated)
            {
                context.Result = new StatusCodeResult(401); //401 não autorizado
                return;
            }

            if (!CustomAuthorization.ValidarClaimsUsuario(context.HttpContext, _claim.Type, _claim.Value))
            {
                //se return false, sabe-se quem é o usuário porém, ele não pode fazer o que ele está tentando  
                context.Result = new StatusCodeResult(403);
            }
        }
    }
}
