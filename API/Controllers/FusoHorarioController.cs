using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.FusoHorarios;
using Domain.Commands.FusoHorarios.Adicionar;
using Application.DTOs.FusoHorarios.Adicionar;
using Domain.Commands.FusoHorarios.Atualizar;
using Application.DTOs.FusoHorarios.Atualizar;
using Domain.Commands.FusoHorarios.Excluir;
using Application.DTOs.FusoHorarios.Excluir;
using Swashbuckle.AspNetCore.Annotations;
using SharedKernel.Helpers.Authorization;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using Application.DTOs.FusoHorarios;
using Application.DTOs.FusoHorarios.Filtro;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FusoHorarioController : PrincipalController
    {
        private readonly IFusoHorarioService _fusoHorarioService;

        public FusoHorarioController(IFusoHorarioService FusoHorarioService)
        {
            _fusoHorarioService = FusoHorarioService;
        }

        /// <response code="201"> Created               - 0000 >> Item adicionado com sucesso.</response>
        /// <response code="206"> PartialContent 		- 0000 >> Item adicionado com sucesso.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Item adicionado com sucesso.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema no cadastro do documento.</response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="409"> Conflict			    - 0000 >> Houve um problema ao realizar esta operação, operação já ocorrida. </response>    
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Cria-se um novo Fuso Horario")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FusoHorarioAccessControl.Create)]
        [HttpPost("criar-fuso-horario")]
        public async Task<FormularioResponse<AdicionarFusoHorarioCommand>> Post([FromBody] AdicionarFusoHorarioRequestDto addFusoHorarioDto, CancellationToken cancellationToken)
        {
            var responseService = await _fusoHorarioService.Adicionar(addFusoHorarioDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Item alterado com sucesso.</response>
        /// <response code="206"> PartialContent 		- 0000 >> Item alterado com sucesso.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Item alterado com sucesso.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema na edição do documento.</response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="409"> Conflict			    - 0000 >> Houve um problema ao realizar esta operação, operação já ocorrida. </response>    
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Atualiza o Fuso Horario")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarFusoHorarioCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FusoHorarioAccessControl.Update)]
        [HttpPut("atualizar-fuso-horario")]
        public async Task<FormularioResponse<AtualizarFusoHorarioCommand>> Put([FromBody] AtualizarFusoHorarioRequestDto updateFusoHorarioDto, CancellationToken cancellationToken)
        {
            var responseService = await _fusoHorarioService.Atualizar(updateFusoHorarioDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Item excluído com sucesso.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Item excluído com sucesso.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Houve um problema na exclusão do documento. </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="409"> Conflict			    - 0000 >> Houve um problema ao realizar esta operação, operação já ocorrida. </response>    
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Exclui um ou mais Fuso Horarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FusoHorarioAccessControl.Delete)]
        [HttpDelete("remove-fuso-horario")]
        public async Task<List<FormularioResponse<ExcluirFusoHorarioCommand>>> Delete([FromBody] ExcluirFusoHorarioDto deleteFusoHorarioDto, CancellationToken cancellationToken)
        {
            var responseService = await _fusoHorarioService.Excluir(deleteFusoHorarioDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Fuso Horarios")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<FusoHorarioFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<FusoHorarioFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FusoHorarioAccessControl.Read)]
        [HttpGet("retornar-fuso-horario")]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _fusoHorarioService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Fuso Horario por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<FusoHorarioByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<FusoHorarioByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FusoHorarioAccessControl.Read)]
        [HttpGet("get-fuso-horario-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _fusoHorarioService.RetornarPorId(id);
            return CustomResponse(responseService);
        }
    }
}
