using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.SharedObjects;
using System.Net;
using System.Security.Authentication;
using Microsoft.AspNetCore.Http;

namespace SharedKernel.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class ErrorController : MainController
    {
        [Route("error")]
        public NewResponse Error()
        {
            var exception = HttpContext.Features.Get<IExceptionHandlerFeature>()!.Error;
            var statusCode = (int)HttpStatusCode.InternalServerError;

            if (exception is DomainException)
            {
                statusCode = ((DomainException)exception).StatusCode;
            }
            else if (exception is FileNotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
                var newResponse = new NewResponse(statusCode);
                newResponse.Errors = "Arquivo não encontrado";
                SetResponseStatusCode(statusCode);
                return newResponse;
            }
            else if (exception is NotImplementedException) statusCode = (int)HttpStatusCode.NotFound;
            else if (exception is NotSupportedException) statusCode = (int)HttpStatusCode.MethodNotAllowed;
            else if (exception is UnauthorizedAccessException) statusCode = (int)HttpStatusCode.Forbidden;
            else if (exception is AuthenticationException) statusCode = (int)HttpStatusCode.Unauthorized;
            else if (exception is BadHttpRequestException) statusCode = ((BadHttpRequestException)exception).StatusCode;

            SetResponseStatusCode(statusCode);

            var responseDTO = new NewResponse(statusCode);
            responseDTO.Errors = exception.Message;
            return responseDTO;
        }

        public void SetResponseStatusCode(int StatusCode)
        {
            if (Response.StatusCode != StatusCode)
                Response.StatusCode = StatusCode;
        }
    }
}
