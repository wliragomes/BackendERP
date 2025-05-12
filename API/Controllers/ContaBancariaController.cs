using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.Interfaces.ContasBancarias;
using Domain.Commands.ContasBancarias.Adicionar;
using Application.DTOs.ContasBancarias.Adicionar;
using Domain.Commands.ContasBancarias.Atualizar;
using Application.DTOs.ContasBancarias.Atualizar;
using Domain.Commands.ContasBancarias.Excluir;
using Application.DTOs.ContasBancarias.Excluir;
using Swashbuckle.AspNetCore.Annotations;
using SharedKernel.Helpers.Authorization;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using Application.DTOs.ContasBancarias;
using Application.DTOs.ContasBancarias.Filtro;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContaBancariaController : PrincipalController
    {
        private readonly IContaBancariaService _contaBancariaService;

        public ContaBancariaController(IContaBancariaService ContaBancariaService)
        {
            _contaBancariaService = ContaBancariaService;
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
        [SwaggerOperation(Summary = "Cria-se uma nova Conta Bancária")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ContaBancariaAccessControl.Create)]
        [HttpPost("criar-conta-bancaria")]
        public async Task<FormularioResponse<AdicionarContaBancariaCommand>> Post([FromBody] AdicionarContaBancariaRequestDto addContaBancariaDto, CancellationToken cancellationToken)
        {
            var responseService = await _contaBancariaService.Adicionar(addContaBancariaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza a Conta Bancária")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarContaBancariaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ContaBancariaAccessControl.Update)]
        [HttpPut("atualizar-conta-bancaria")]
        public async Task<FormularioResponse<AtualizarContaBancariaCommand>> Put([FromBody] AtualizarContaBancariaRequestDto updateContaBancariaDto, CancellationToken cancellationToken)
        {
            var responseService = await _contaBancariaService.Atualizar(updateContaBancariaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui uma ou mais Contas Bancarias")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ContaBancariaAccessControl.Delete)]
        [HttpDelete("remove-conta-bancaria")]
        public async Task<List<FormularioResponse<ExcluirContaBancariaCommand>>> Delete([FromBody] ExcluirContaBancariaDto deleteContaBancariaDto, CancellationToken cancellationToken)
        {
            var responseService = await _contaBancariaService.Excluir(deleteContaBancariaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Contas Bancárias")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ContaBancariaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ContaBancariaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ContaBancariaAccessControl.Read)]
        [HttpGet("retornar-contas-bancarias")]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _contaBancariaService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Conta Bancaria por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<ContaBancariaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<ContaBancariaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ContaBancariaAccessControl.Read)]
        [HttpGet("get-conta-bancaria-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _contaBancariaService.RetornarPorId(id);
            return CustomResponse(responseService);
        }
    }
}
