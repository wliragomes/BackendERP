using Application.DTOs.Auth;
using Application.Interfaces.Auth;
using Domain.Commands.Auth;
using Domain.Commands.Auth.ForgottenPassword;
using Domain.Commands.Auth.RecoveryPassword;
using Domain.Commands.Auth.UpdateAnyPassword;
using Domain.Commands.Auth.UpdatePassword;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.DTOs.ProducesResponsesTypes;
using SharedKernel.SharedObjects;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : PrincipalController
    {
        private readonly IAuthService _authService;
        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        /// <response code="201"> Created               - 0000 >> Login efetuado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Tentativa de login")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<LoginCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<LoginCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost]
        [AllowAnonymous]
        public async Task<FormularioResponse<LoginCommand>> Post([FromBody] LoginValueDto loginDto, CancellationToken cancellationToken)
        {
            var responseService = await _authService.Login(loginDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Logout efetuado com sucesso.</response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Deslogar")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<bool>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [HttpPost("logout")]
        public async Task<ActionResult<bool>> Logout()
        {
            var authHeader = Request.Headers["Authorization"].ToString();

            var result = await _authService.Logout(authHeader);
            return CustomResponse();
        }

        /// <response code="200"> Ok Result             - 0000 >> Usuario desbloqueado com sucesso.</response>
        /// <response code="400"> Bad Request		    - 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Desbloquear usuário")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<bool>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<ForgottenPasswordCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [HttpPost("unblock")]
        [AllowAnonymous]
        public async Task<ActionResult<bool>> Unblock([FromBody] UnBlockedByCodeDto unBlockedByCodeDto)
        {
            //Será enviado um codigo para desbloquear o usuário, no banco de dados terá uma data para esse código expirar, esse endpoint retornará true se o código for válido e estiver dentro do prazo de expiração
            var result = await _authService.UnblockByCode(unBlockedByCodeDto);
            if (result)
                return CustomResponse();
            else
                return CustomResponse(HttpStatusCode.BadRequest, "Código de desbloqueio inválido");
        }
        
        /// <response code="201"> Created               - 0000 >> Esqueci minha senha efetuado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Lembrar senha - Falta terminar")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKListType<ForgottenPasswordCommand>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<ForgottenPasswordCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("lembrar-senha")]
        [AllowAnonymous]
        public async Task<FormularioResponse<ForgottenPasswordCommand>> ForgottenPassord([FromBody] ForgottenPasswordValueDto forgottenPasswordDto, CancellationToken cancellationToken)
        {
            var responseService = await _authService.ForgottenPassword(forgottenPasswordDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="201"> Created               - 0000 >> Recuperar senha efetuado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Recuperar senha - Falta terminar")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKListType<RecoveryPasswordCommand>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<RecoveryPasswordCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("recuperar-senha")]
        [AllowAnonymous]
        public async Task<FormularioResponse<RecoveryPasswordCommand>> RecoveryPassord([FromBody] RecoveryPasswordDto recoveryPasswordDto, CancellationToken cancellationToken)
        {
            var responseService = await _authService.RecoveryPassword(recoveryPasswordDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="201"> Created               - 0000 >> Alteração de senha efetuado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Alteração de senha. Precisa estar logado.")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKListType<RecoveryPasswordCommand>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<RecoveryPasswordCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("alterar-senha")]
        public async Task<FormularioResponse<UpdateLoginPasswordCommand>> UpdateLoginPassword([FromBody] UpdateLoginPasswordDto updatePasswordDto, CancellationToken cancellationToken)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var responseService = await _authService.UpdatePassword(authHeader, updatePasswordDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="201"> Created               - 0000 >> Alteração de senha efetuado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Alteração de senha. Não precisa estar logado. - Falta terminar")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKListType<UpdateAnyPasswordCommand>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<UpdateAnyPasswordCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("alterar-qualquer-senha")]
        [AllowAnonymous]
        public async Task<FormularioResponse<UpdateAnyPasswordCommand>> UpdateAnyPassword([FromBody] UpdateAnyPasswordDto updatePasswordDto, CancellationToken cancellationToken)
        {
            var responseService = await _authService.UpdateAnyPassword(updatePasswordDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="201"> Created               - 0000 >> Token atualizado com sucesso.</response>
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>
        [SwaggerOperation(Summary = "Atualizar token")]
        //[ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKListType<RefreshCommand>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKListType<RefreshCommand>))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        [HttpPost("atualizar")]
        public async Task<FormularioResponse<RefreshCommand>> Refresh(CancellationToken cancellationToken)
        {
            var authHeader = Request.Headers["Authorization"].ToString();
            var responseService = await _authService.Refresh(authHeader, cancellationToken);
            return CustomResponse(responseService);
        }
    }
}
