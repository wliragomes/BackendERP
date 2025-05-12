using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.MinimoCobrancas;
using Domain.Commands.MinimoCobrancas.Adicionar;
using Application.DTOs.MinimoCobrancas.Adicionar;
using Domain.Commands.MinimoCobrancas.Atualizar;
using Application.DTOs.MinimoCobrancas.Atualizar;
using Domain.Commands.MinimoCobrancas.Excluir;
using Application.DTOs.MinimoCobrancas.Excluir;
using Swashbuckle.AspNetCore.Annotations;
using SharedKernel.Helpers.Authorization;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using Application.DTOs.MinimoCobrancas;
using Application.DTOs.MinimoCobrancas.Filtro;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MinimoCobrancaController : PrincipalController
    {
        private readonly IMinimoCobrancaService _minimoCobrancaService;

        public MinimoCobrancaController(IMinimoCobrancaService MinimoCobrancaService)
        {
            _minimoCobrancaService = MinimoCobrancaService;
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
        [SwaggerOperation(Summary = "Cria-se uma nova Cobrança Mínima")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MinimoCobrancaAccessControl.Create)]
        [HttpPost("criar-minimo-cobranca")]
        public async Task<FormularioResponse<AdicionarMinimoCobrancaCommand>> Post([FromBody] AdicionarMinimoCobrancaRequestDto addMinimoCobrancaDto, CancellationToken cancellationToken)
        {
            var responseService = await _minimoCobrancaService.Adicionar(addMinimoCobrancaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza a Cobrança Mínima")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarMinimoCobrancaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MinimoCobrancaAccessControl.Update)]
        [HttpPut("atualizar-minimo-cobranca")]
        public async Task<FormularioResponse<AtualizarMinimoCobrancaCommand>> Put([FromBody] AtualizarMinimoCobrancaRequestDto updateMinimoCobrancaDto, CancellationToken cancellationToken)
        {
            var responseService = await _minimoCobrancaService.Atualizar(updateMinimoCobrancaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui uma ou mais Cobrancas Mínima")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MinimoCobrancaAccessControl.Delete)]
        [HttpDelete("remove-minimo-cobranca")]
        public async Task<List<FormularioResponse<ExcluirMinimoCobrancaCommand>>> Delete([FromBody] ExcluirMinimoCobrancaDto deleteMinimoCobrancaDto, CancellationToken cancellationToken)
        {
            var responseService = await _minimoCobrancaService.Excluir(deleteMinimoCobrancaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Cobranças Mínima")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<MinimoCobrancaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<MinimoCobrancaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MinimoCobrancaAccessControl.Read)]
        [HttpGet("retornar-minimo-cobranca")]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _minimoCobrancaService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Cobrança Mínima por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<MinimoCobrancaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<MinimoCobrancaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MinimoCobrancaAccessControl.Read)]
        [HttpGet("get-minimo-cobranca-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _minimoCobrancaService.RetornarPorId(id);
            return CustomResponse(responseService);
        }
    }
}
