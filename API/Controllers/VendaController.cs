using API.AccessControlDefinition;
using Application.DTOs.TiposFretes;
using Application.DTOs.TiposFretes.Adicionar;
using Application.DTOs.TiposFretes.Atualizar;
using Application.DTOs.TiposFretes.Excluir;
using Application.DTOs.TiposFretes.Filtro;
using Application.DTOs.Venda.Adicionar;
using Application.DTOs.Venda.Atualizar;
using Application.DTOs.Venda.Excluir;
using Application.DTOs.Vendas.Filtro;
using Application.Interfaces.Vendas;
using Domain.Commands.TipoFretes.Adicionar;
using Domain.Commands.TipoFretes.Atualizar;
using Domain.Commands.TipoFretes.Excluir;
using Domain.Commands.Vendas.Adicionar;
using Domain.Commands.Vendas.Atualizar;
using Domain.Commands.Vendas.Excluir;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.DTOs.ProducesResponsesTypes;
using SharedKernel.Helpers.Authorization;
using SharedKernel.SharedObjects;
using SharedKernel.SharedObjects.Paginations;
using Swashbuckle.AspNetCore.Annotations;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VendaController : PrincipalController
    {
        private readonly IVendaService _vendaService;

        public VendaController(IVendaService VendaService)
        {
            _vendaService = VendaService;
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
        [SwaggerOperation(Summary = "Cria-se uma nova Venda")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(VendaAccessControl.Create)]
        [HttpPost]
        public async Task<FormularioResponse<AdicionarVendaCommand>> Post([FromBody] AdicionarVendaRequestDto addVendaDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.Adicionar(addVendaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza a Venda")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarVendaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(VendaAccessControl.Update)]
        [HttpPut]
        public async Task<FormularioResponse<AtualizarVendaCommand>> Put([FromBody] AtualizarVendaRequestDto updateVendaDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.Atualizar(updateVendaDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui uma ou mais Vendas")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(VendaAccessControl.Delete)]
        [HttpDelete]
        public async Task<List<FormularioResponse<ExcluirVendaCommand>>> Delete([FromBody] ExcluirVendaDto deleteVendaDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.Excluir(deleteVendaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Venda")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<VendaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<VendaFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(VendaAccessControl.Read)]
        [HttpGet]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _vendaService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        ///// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        ///// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        ///// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        ///// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        ///// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        ///// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        ///// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        //[SwaggerOperation(Summary = "Lista de Venda por Ordem de Fabricação")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<VendaOrdemFabricacaoFilterDto>))]
        //[ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<VendaOrdemFabricacaoFilterDto>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        //[ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        //[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        //[CustomAuthorize(VendaAccessControl.Read)]
        //[HttpGet("lista-venda-ordem-fabricacao")]
        //public async Task<ActionResult> GetOrdemFabricacaoFilter([FromQuery] PaginacaoRequest paginationRequest)
        //{
        //    var responseService = await _vendaService.RetornarOrdemFabricacaoPaginacao(paginationRequest);
        //    return CustomPaginationResponse(responseService);
        //}


        [HttpGet("lista-venda-ordem-fabricacao")]
        public async Task<ActionResult> RetornarOrdemFabricacao(string codigoAnoVenda)
        {
            var responseService = await _vendaService.RetornarOrdemFabricacao(codigoAnoVenda);
            return CustomResponse(responseService);
        }








        [HttpGet("retornar-venda-of-romaneio")]
        public async Task<ActionResult> RetornarVendaOfRomaneio(int sqOrdemFabricacaoCodigo, int sqOrdemFabricacaoAno)
        {
            var responseService = await _vendaService.RetornarVendaOfRomaneio(sqOrdemFabricacaoCodigo, sqOrdemFabricacaoAno);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Venda por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<VendaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<VendaByCodeDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(VendaAccessControl.Read)]
        [HttpGet("get-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _vendaService.RetornarPorId(id);
            return CustomResponse(responseService);
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
        [SwaggerOperation(Summary = "Cria-se um Novo Tipo de Frete")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoFreteAccessControl.Create)]

        [HttpPost("adicionar-tipo-frete")]
        public async Task<FormularioResponse<AdicionarTipoFreteCommand>> Post([FromBody] AdicionarTipoFreteRequestDto addTipoFreteDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.AdicionarTipoFrete(addTipoFreteDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza Tipo de Frete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarTipoFreteCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoFreteAccessControl.Update)]
        [HttpPut("atualiza-tipo-frete")]
        public async Task<FormularioResponse<AtualizarTipoFreteCommand>> PutTipoFrete([FromBody] AtualizarTipoFreteRequestDto updateTipoFreteDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.AtualizarTipoFrete(updateTipoFreteDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Remove um Tipo de Frete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoFreteAccessControl.Delete)]
        [HttpDelete("delete-tipo-frete")]
        public async Task<List<FormularioResponse<ExcluirTipoFreteCommand>>> DeleteTipoFrete([FromBody] ExcluirTipoFreteDto deleteTipoFreteDto, CancellationToken cancellationToken)
        {
            var responseService = await _vendaService.ExcluirTipoFrete(deleteTipoFreteDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Tipos de Frete")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<TipoFreteFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<TipoFreteDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoFreteAccessControl.Read)]
        [HttpGet("get-tipo-de-frete")]
        public async Task<ActionResult> GetFilterTipoFrete([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _vendaService.RetornarTipoFretePaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Tipo de Frete por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<TipoFreteFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<TipoFreteFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoFreteAccessControl.Read)]
        [HttpGet("get-tipo-de-frete-by-id")]
        public async Task<ActionResult> GetByIdTipoFrete(Guid id)
        {
            var responseService = await _vendaService.RetornarTipoFretePorId(id);
            return CustomResponse(responseService);
        }

        [HttpGet("impressao")]
        public async Task<ActionResult>Impressao(Guid idVenda, bool especial, bool orcamento, Guid idCliente, bool suprimirVendedor)
        {
            var responseService = await _vendaService.RetornarImpressao(idVenda, especial, orcamento, idCliente, suprimirVendedor);
            return CustomReportPdfResponse(responseService);
        }

        [CustomAuthorize(PessoaAccessControl.Read)]
        [HttpGet("get-tipo-fechamento")]
        public async Task<ActionResult> GetTipoFechamentoFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _vendaService.RetornarTipoFechamentoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }
    }
}
