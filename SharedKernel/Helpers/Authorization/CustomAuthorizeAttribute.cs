using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.SharedObjects;
using System.Net;
using System.Security.Claims;

namespace SharedKernel.Helpers.Authorization
{
    public class CustomAuthorizeAttribute : TypeFilterAttribute
    {
        public CustomAuthorizeAttribute(string claimValue) : base(typeof(RequestClaimFilter))
        {
            Arguments = new object[] { new Claim("AccessControl", claimValue) };
        }
    }

    public class RequestClaimFilter : IAuthorizationFilter
    {
        private readonly Claim _claim;

        public RequestClaimFilter(Claim claim)
        {
            _claim = claim;
        }

        public void OnAuthorization(AuthorizationFilterContext context)
        {
            bool hasClaim;

            //if (context.HttpContext.User.Claims.Any(x => x.Type == "SystemOperation" && x.Value == "Core"))
            //    return;

            if (context.HttpContext?.User?.Claims == null)
                hasClaim = false;
            else
                hasClaim = context.HttpContext.User.Claims.Any(c => c.Type == "AccessControl" &&
                                                                    c.Value == _claim.Value);

            if (!hasClaim)
            {
                context.Result = new JsonResult(new NewResponse()
                {
                    StatusCode = (int)HttpStatusCode.Forbidden,
                    Errors = "Sem permissão para realizar esta operação, entre em contato com o suporte."
                })
                { StatusCode = (int)HttpStatusCode.Forbidden };
            }
        }
    }
}
