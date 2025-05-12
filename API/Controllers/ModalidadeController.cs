using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.Modalidades;
using Domain.Commands.Modalidades.Adicionar;
using Application.DTOs.Modalidades.Adicionar;
using Domain.Commands.Modalidades.Atualizar;
using Application.DTOs.Modalidades.Atualizar;
using Domain.Commands.Modalidades.Excluir;
using Application.DTOs.Modalidades.Excluir;
using Swashbuckle.AspNetCore.Annotations;
using SharedKernel.Helpers.Authorization;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using Application.DTOs.Modalidades;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ModalidadeController : PrincipalController
    {
        private readonly IModalidadeService _modalidadeService;

        public ModalidadeController(IModalidadeService ModalidadeService)
        {
            _modalidadeService = ModalidadeService;
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
        [SwaggerOperation(Summary = "Cria-se uma nova Modalidade")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ModalidadeAccessControl.Create)]
        [HttpPost("criar-modalidade")]
        public async Task<FormularioResponse<AdicionarModalidadeCommand>> Post([FromBody] AdicionarModalidadeRequestDto addModalidadeDto, CancellationToken cancellationToken)
        {
            var responseService = await _modalidadeService.Adicionar(addModalidadeDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza a Modalidade")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarModalidadeCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ModalidadeAccessControl.Update)]
        [HttpPut("atualiza-modalidade")]
        public async Task<FormularioResponse<AtualizarModalidadeCommand>> Put([FromBody] AtualizarModalidadeRequestDto updateModalidadeDto, CancellationToken cancellationToken)
        {
            var responseService = await _modalidadeService.Atualizar(updateModalidadeDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui uma ou mais Modalidades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ModalidadeAccessControl.Delete)]
        [HttpDelete("remove-modalidade")]
        public async Task<List<FormularioResponse<ExcluirModalidadeCommand>>> Delete([FromBody] ExcluirModalidadeDto deleteModalidadeDto, CancellationToken cancellationToken)
        {
            var responseService = await _modalidadeService.Excluir(deleteModalidadeDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Modalidades")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ModalidadeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ModalidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ModalidadeAccessControl.Read)]
        [HttpGet("retornar-modalidade")]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _modalidadeService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Modalidade por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<ModalidadeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<ModalidadeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ModalidadeAccessControl.Read)]
        [HttpGet("get-modalidade-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _modalidadeService.RetornarPorId(id);
            return CustomResponse(responseService);
        }
    }
}
