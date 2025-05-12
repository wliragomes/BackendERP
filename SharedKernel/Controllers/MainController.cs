using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SharedKernel.Helpers;
using SharedKernel.SharedObjects;
using System.Net;

namespace SharedKernel.Controllers
{
    [Authorize]
    public class MainController : ControllerBase
    {
        private bool _alreadySetError = false;

        private string IdAccountToLog { get; set; } = "";
        private object InputToLog { get; set; } = null;
        private object OutPutToLog { get; set; } = null;
        private LogStatus LogStatus { get; set; } = LogStatus.OK;

        protected List<object> Errors = new List<object>();

        protected ActionResult CustomResponse(object? response = null)
        {
            if (HasError())
            {
                var responseDTO = CreateResponseWithErrors();
                return BadRequest(responseDTO);
            }

            if (response is null) return Ok(new NewResponse());
            return Ok(new NewResponse(response));
        }

        protected ActionResult CustomResponse(HttpStatusCode statusCode, object errors, object? response = null)
        {
            if ((int)statusCode == (int)HttpStatusCode.OK)
            {
                return CustomResponse(response);
            }

            return new UnprocessableEntityObjectResult(new NewResponse(response!, (int)HttpStatusCode.UnprocessableEntity, errors));
        }

        protected List<TesteResponse<T>> CustomResponse<T>(List<TesteResponse<T>> responses)
        {
            foreach (var response in responses)
            {
                SetResponseStatusCode(response);
            }

            return responses;
        }

        protected TesteResponse<T> CustomResponse<T>(TesteResponse<T> response)
        {
            SetResponseStatusCode(response);
            return response;
        }

        private void SetResponseStatusCode<T>(TesteResponse<T> response)
        {
            if (response.HasError())
            {
                SetBadRequest(response);
            }
            else
            {
                SetSuccessRequest(response);
            }
        }

        private void SetBadRequest<T>(TesteResponse<T> response)
        {
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.ChangeStatusCode(Response.StatusCode);
            _alreadySetError = true;
        }

        private void SetSuccessRequest<T>(TesteResponse<T> response)
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
            return Errors.Any();
        }

        private void AddError(object erro)
        {
            if (!Errors.Contains(erro))
                Errors.Add(erro);
        }

        private NewResponse CreateResponseWithErrors()
        {
            var responseDTO = new NewResponse();
            responseDTO.StatusCode = (int)HttpStatusCode.BadRequest;
            responseDTO.Errors = Errors;
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

        protected Guid? GetCanalId()
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var token = APIs.Security.JWT.Util.Utils.GetTokenFromHeader(authHeader);
            var canalIdString = APIs.Security.JWT.Util.Utils.GetItemFromToken(token, "CanalId");

            if (canalIdString != null)
            {
                return Guid.Parse(canalIdString);
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
