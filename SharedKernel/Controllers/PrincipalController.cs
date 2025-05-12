using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Helpers;
using System.Net;
using SharedKernel.SharedObjects;
using FluentValidation.Results;

namespace SharedKernel.Controllers
{
    [Authorize]
    public class PrincipalController : ControllerBase
    {
        private bool _alreadySetError = false;
        private string IdAccountToLog { get; set; } = "";
        private object InputToLog { get; set; } = null;
        private object OutputToLog { get; set; } = null;
        private LogStatus LogStatus { get; set; } = LogStatus.OK;

        protected List<object> Erros = new List<object>();

        protected ActionResult CustomResponse(object? response = null)
        {
            if (HasError())
            {
                var responseDTO = CreateResponseWithErrors();
                return BadRequest(responseDTO);
            }

            if (response is null) return Ok(new Response());
            return Ok(new Response(response));
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode, object erros, object? response = null)
        {
            if ((int)statusCode == (int)HttpStatusCode.OK)
            {
                return CustomResponse(response);
            }

            return new UnprocessableEntityObjectResult(new Response(response!, (int)HttpStatusCode.UnprocessableEntity, erros));
        }

        protected List<FormularioResponse<T>> CustomResponse<T>(List<FormularioResponse<T>> responses)
        {
            foreach (var response in responses)
            {
                SetResponseStatusCode(response);
            }

            return responses;
        }

        protected FormularioResponse<T> CustomResponse<T>(FormularioResponse<T> response)
        {
            SetResponseStatusCode(response);
            return response;
        }

        private void SetResponseStatusCode<T>(FormularioResponse<T> response)
        {
            if (response.ExisteErro())
            {
                SetBadRequest(response);
            }
            else
            {
                SetSuccessRequest(response);
            }
        }

        private void SetBadRequest<T>(FormularioResponse<T> response)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ChangeStatusCode(Response.StatusCode);
            _alreadySetError = true;
        }

        private void SetSuccessRequest<T>(FormularioResponse<T> response)
        {
            var statusCode = IsDeleteOrPutOrPatchRequest() ? (int)HttpStatusCode.OK : (int)HttpStatusCode.Created;

            if (!_alreadySetError)
                Response.StatusCode = statusCode;

            response.ChangeStatusCode(statusCode);
        }

        private bool IsDeleteOrPutOrPatchRequest()
        {
            var method = HttpContext.Request.Method;
            return method == HttpMethods.Patch || method == HttpMethods.Put || method == HttpMethods.Delete;
        }

        protected ActionResult CustomPaginationResponse(object paginationResponse)
        {
            return Ok(paginationResponse);
        }

        protected ActionResult CustomReportResponse(object reportResponse)
        {
            return Ok(new { fileName = reportResponse });
        }

        protected ActionResult CustomReportPdfResponse(object reportResponse)
        {
            if (reportResponse is byte[] pdfBytes)
            {
                return File(pdfBytes, "application/pdf", "Relatorio.pdf");
            }

            return Ok(reportResponse);
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var erros = modelState.Values.SelectMany(e => e.Errors);
            foreach (var erro in erros)
            {
                AddError(erro.ErrorMessage);
            }
            return CustomResponse();
        }

        protected ActionResult CustomResponse(ValidationResult validationResult)
        {
            foreach (var error in validationResult.Errors)
            {
                var addError = new
                {
                    error.PropertyName,
                    PropertyValue = error.AttemptedValue,
                    message = error.ErrorMessage
                };
                AddError(addError);
            }
            return CustomResponse();
        }

        private bool HasError()
        {
            return Erros.Any();
        }

        private void AddError(object erro)
        {
            if (!Erros.Contains(erro))
                Erros.Add(erro);
        }

        private Response CreateResponseWithErrors()
        {
            var responseDTO = new Response();
            responseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
            responseDTO.Erros = Erros;
            return responseDTO;
        }

        protected Guid? GetUserId()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            var userIdString = APIs.Security.JWT.Util.Utils.GetUserIdFromToken(token);

            if (userIdString != null && Guid.TryParse(userIdString, out Guid userId))
            {
                return userId;
            }

            return null;
        }

        protected string? GetUserCode()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            var userCodeString = APIs.Security.JWT.Util.Utils.GetUserCodeFromToken(token);

            if (userCodeString != null)
            {
                return userCodeString;
            }

            return null;
        }

        protected string? GetUserName()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            var userNameString = APIs.Security.JWT.Util.Utils.GetUserNameFromToken(token);

            if (userNameString != null)
            {
                return userNameString;
            }

            return null;
        }

        protected Guid? GetIdAdministrador()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            var strAdministrador = APIs.Security.JWT.Util.Utils.GetIdAdministradorFromToken(token);

            if (strAdministrador != null)
            {
                return Guid.Parse(strAdministrador);
            }

            return null;
        }

        protected string? GetCurrentToken()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            return token;
        }
    }
}
