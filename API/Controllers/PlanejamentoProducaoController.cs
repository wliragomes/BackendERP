using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using Application.Interfaces.PlanejamentoProducaos;
using Swashbuckle.AspNetCore.Annotations;
using SharedKernel.Helpers.Authorization;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using Domain.Commands.PlanejamentoProducaos.Atualizar;
using Application.DTOs.PlanejamentoProducaos.Atualizar;
using SharedKernel.SharedObjects;
using Application.DTOs.PlanejamentosProducoes;
using SharedKernel.SharedObjects.Paginations;
using Application.DTOs.OrdensFabricacoes.Filtro;
using Application.DTOs.PlanejamentoProducoes.Filtro;
using Application.DTOs.Moedas;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlanejamentoProducaoController : PrincipalController
    {
        private readonly IPlanejamentoProducaoService _planejamentoProducaoService;

        public PlanejamentoProducaoController(IPlanejamentoProducaoService PlanejamentoProducaoService)
        {
            _planejamentoProducaoService = PlanejamentoProducaoService;
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
        [SwaggerOperation(Summary = "Atualiza Planejamento de Producao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarPlanejamentoProducaoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarPlanejamentoProducaoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarPlanejamentoProducaoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarPlanejamentoProducaoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PlanejamentoProducaoAccessControl.Update)]
        [HttpPut("atualizar-planejamento-producao")]
        public async Task<FormularioResponse<AtualizarPlanejamentoProducaoCommand>> Put([FromBody] AtualizarPlanejamentoProducaoRequestDto updatePlanejamentoProducaoDto, CancellationToken cancellationToken)
        {
            var responseService = await _planejamentoProducaoService.Atualizar(updatePlanejamentoProducaoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Planejamento de Producao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PlanejamentoProducaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PlanejamentoProducaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PlanejamentoProducaoAccessControl.Read)]
        [HttpGet("retornar-planejamento-producao")]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _planejamentoProducaoService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Composição por Produto")]
        [CustomAuthorize(OrdemFabricacaoAccessControl.Read)]
        [HttpGet("retornar-composicao-por-produto")]
        public async Task<ActionResult> ExibirComposicao([FromQuery] Guid idProduto)
        {
            var responseService = await _planejamentoProducaoService.ExibirComposicao(idProduto);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Planejamento de Produção por Setor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<MoedaDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<MoedaDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(MoedaAccessControl.Read)]
        [HttpGet("get-Planejamento-by-id-setor-produto")]
        public async Task<ActionResult> GetByIdSetorProduto(Guid idSetorProduto)
        {
            var responseService = await _planejamentoProducaoService.RetornarPorIdSetorProduto(idSetorProduto);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Reposição")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PlanejamentoProducaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PlanejamentoProducaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PlanejamentoProducaoAccessControl.Read)]
        [HttpGet("retornar-reposicao")]
        public async Task<ActionResult> GetReposicaoFilter([FromQuery] bool reposicao)
        {
            var responseService = await _planejamentoProducaoService.RetornarReposicao(reposicao);
            return CustomPaginationResponse(responseService);
        }
    }
}