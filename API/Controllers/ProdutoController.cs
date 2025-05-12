using Application.Interfaces.Produtos;
using Domain.Commands.Produtos.Adicionar;
using Domain.Commands.Produtos.Atualizar;
using Microsoft.AspNetCore.Mvc;
using SharedKernel.Controllers;
using SharedKernel.SharedObjects.Paginations;
using SharedKernel.SharedObjects;
using Application.DTOs.Produto.Adicionar;
using Application.DTOs.Produtos.Atualizar;
using API.AccessControlDefinition;
using SharedKernel.DTOs.ProducesResponsesTypes;
using SharedKernel.Helpers.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using Application.DTOs.Produtos;
using Application.DTOs.Pessoas.Filtro;
using Domain.Commands.Produtos.Grupos.Atualizar;
using Domain.Commands.Produtos.CodigosImportacoes.Atualizar;
using Application.DTOs.Produtos.CodigosImportacoes.Atualizar;
using Application.DTOs.Produtos.CodigosImportacoes.Adicionar;
using Domain.Commands.Produtos.CodigosImportacoes.Adicionar;
using Domain.Commands.Produtos.Setores.Atualizar;
using Domain.Commands.Produtos.Setores.Adicionar;
using Application.DTOs.Produtos.Setores.Adicionar;
using Application.DTOs.Produtos.Setores.Atualizar;
using Domain.Commands.Produtos.Ruas.Adicionar;
using Application.DTOs.Produtos.Ruas.Adicionar;
using Domain.Commands.Produtos.Ruas.Atualizar;
using Application.DTOs.Produtos.Ruas.Atualizar;
using Microsoft.AspNetCore.Authorization;
using Domain.Commands.Produtos.Subgrupos.Adicionar;
using Application.DTOs.Produtos.Subgrupos.Adicionar;
using Application.DTOs.Produtos.Subgrupos.Atualizar;
using Domain.Commands.Produtos.Subgrupos.Atualizar;
using Domain.Commands.Produtos.Prateleiras.Adicionar;
using Application.DTOs.Produtos.Prateleiras.Adicionar;
using Domain.Commands.Produtos.Prateleiras.Atualizar;
using Application.DTOs.Produtos.Prateleiras.Atualizar;
using Domain.Commands.Produtos.Ncms.Adicionar;
using Application.DTOs.Produtos.Ncms.Adicionar;
using Application.DTOs.Produtos.Ncms.Atualizar;
using Domain.Commands.Produtos.Ncms.Atualizar;
using Application.DTOs.Produtos.Familias.Adicionar;
using Domain.Commands.Produtos.Familias.Atualizar;
using Application.DTOs.Produtos.Familias.Atualizar;
using Domain.Commands.Produtos.Familias.Adicionar;
using Application.DTOs.Produtos.TiposProdutos.Adicionar;
using Application.DTOs.Produtos.TiposProdutos.Atualizar;
using Domain.Commands.Produtos.TiposProdutos.Adicionar;
using Domain.Commands.Produtos.TiposProdutos.Atualizar;
using Domain.Commands.Produtos.TiposPrecos.Adicionar;
using Application.DTOs.Produtos.TiposPrecos.Adicionar;
using Application.DTOs.Produtos.TiposPrecos.Atualizar;
using Domain.Commands.Produtos.TiposPrecos.Atualizar;
using Domain.Commands.Produtos.SetoresProdutos.Adicionar;
using Application.DTOs.Produtos.SetoresDeProdutos.Adicionar;
using Application.DTOs.Produtos.SetoresDeProdutos.Atualizar;
using Domain.Commands.Produtos.SetoresProdutos.Atualizar;
using Application.DTOs.Produtos.OrigemMateriais.Atualizar;
using Application.DTOs.Produtos.OrigemMateriais.Adicionar;
using Domain.Commands.Produtos.OrigemMateriais.Adicionar;
using Domain.Commands.Produtos.Grupos.Adicionar;
using Application.DTOs.Produtos.Grupos.Adicionar;
using Application.DTOs.Produtos.Grupos.Atualizar;
using Application.DTOs.Produto.Excluir;
using Domain.Commands.Produtos.Excluir;
using Application.DTOs.Produtos.CodigosImportacoes.Excluir;
using Domain.Commands.Produtos.CodigosImportacoes.Excluir;
using Application.DTOs.Produtos.Grupos.Excluir;
using Domain.Commands.Produtos.Grupos.Excluir;
using Application.DTOs.Produtos.Setores.Excluir;
using Domain.Commands.Produtos.Setores.Excluir;
using Domain.Commands.Produtos.Ruas.Excluir;
using Application.DTOs.Produtos.Ruas.Excluir;
using Domain.Commands.Produtos.Subgrupos.Excluir;
using Application.DTOs.Produtos.Subgrupos.Excluir;
using Domain.Commands.Produtos.Prateleiras.Excluir;
using Application.DTOs.Produtos.Prateleiras.Excluir;
using Domain.Commands.Produtos.Ncms.Excluir;
using Application.DTOs.Produtos.Ncms.Excluir;
using Domain.Commands.Produtos.Familias.Excluir;
using Application.DTOs.Produtos.Familias.Excluir;
using Domain.Commands.Produtos.OrigemMateriais.Excluir;
using Application.DTOs.Produtos.OrigemMateriais.Excluir;
using Domain.Commands.Produtos.TiposProdutos.Excluir;
using Application.DTOs.Produtos.TiposProdutos.Excluir;
using Domain.Commands.Produtos.TiposPrecos.Excluir;
using Application.DTOs.Produtos.TiposPrecos.Excluir;
using Domain.Commands.Produtos.SetoresProdutos.Excluir;
using Application.DTOs.Produtos.SetoresDeProdutos.Excluir;
using Application.DTOs.Produtos.Ncms;
using Domain.Commands.Produtos.UnidadesMedidas.Excluir;
using Application.DTOs.Produtos.UnidadesMedidas.Excluir;
using Application.DTOs.Produtos.UnidadesMedidas.Atualizar;
using Domain.Commands.Produtos.UnidadesMedidas.Atualizar;
using Application.DTOs.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.UnidadesMedidas.Adicionar;
using Domain.Commands.Produtos.ClasseReajustes.Adicionar;
using Application.DTOs.Produtos.ClasseReajustes.Adicionar;
using Domain.Commands.Produtos.ClasseReajustes.Atualizar;
using Application.DTOs.Produtos.ClasseReajustes.Atualizar;
using Domain.Commands.Produtos.ClasseReajustes.Excluir;
using Application.DTOs.Produtos.ClasseReajustes.Excluir;
using Domain.Commands.Produtos.DesgastePolimentos.Adicionar;
using Application.DTOs.Produtos.DesgastePolimentos.Adicionar;
using Domain.Commands.Produtos.AtualizarDesgastes.Atualizar;
using Application.DTOs.Produtos.DesgastePolimentos.Atualizar;
using Application.DTOs.Produtos.DesgastePolimentos.Excluir;
using Domain.Commands.Produtos.DesgastePolimentos.Excluir;
using Application.DTOs.Produtos.ClasseReajustes.Filtro;
using Application.DTOs.Produtos.DesgastePolimentos.Filtro;
using Application.DTOs.Produtos.ClasseReajustes;
using Application.DTOs.Produtos.DesgastePolimentos;
using Application.DTOs.Produtos.Filtro;
using Application.DTOs.Produtos.SetoresDeProdutos.Filtro;

namespace API.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    
    public class ProdutoController : PrincipalController
    {
        private readonly IProdutoService _produtoService;

        public ProdutoController(IProdutoService produtoService)
        {
            _produtoService = produtoService;
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
        [SwaggerOperation(Summary = "Cria-se um novo Produto")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Create)]
        
        [HttpPost]
        public async Task<FormularioResponse<AdicionarProdutoCommand>> Post([FromBody] AdicionarProdutoRequestDto addProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Adicionar(addProdutoDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza o Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Update)]
        [HttpPut]
        public async Task<FormularioResponse<AtualizarProdutoCommand>> Put([FromBody] AtualizarProdutoRequestDto updateProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Atualizar(updateProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Delete)]        

        [HttpDelete]
        public async Task<List<FormularioResponse<ExcluirProdutoCommand>>> Delete([FromBody] ExcluirProdutoDto deleteProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Produtos")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ProdutoDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ProdutoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Read)]
        [HttpGet]
        public async Task<ActionResult> GetFilter([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        ///// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        ///// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        ///// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        ///// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        ///// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        ///// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        ///// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>   

        //[SwaggerOperation(Summary = "Produtos Ordem de Fabricacao")]
        //[ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ProdutoOrdemFabricacaoFilterDto>))]
        //[ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ProdutoOrdemFabricacaoFilterDto>))]
        //[ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        //[ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        //[ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        //[ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        //[ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        //[CustomAuthorize(ProdutoAccessControl.Read)]
        //[HttpGet("produto-ordem-fabricacao")]
        //public async Task<ActionResult> GetProdutoOrdemFabricacaoFilter([FromQuery] PaginacaoRequest paginationRequest)
        //{
        //    var responseService = await _produtoService.RetornarProdutoOrdemFabricacaoPaginacao(paginationRequest);
        //    return CustomPaginationResponse(responseService);
        //}

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>   

        [SwaggerOperation(Summary = "Produtos Ordem de Fabricacao por venda")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ProdutoOrdemFabricacaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ProdutoOrdemFabricacaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Read)]
        [HttpGet("produto-ordem-fabricacao-por-venda")]
        public async Task<ActionResult> GetRetornarProdutoPorVendaPaginacao([FromQuery] Guid idVenda)
        {
            var responseService = await _produtoService.RetornarProdutoPorVendaPaginacao(idVenda);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response> 



        [SwaggerOperation(Summary = "Retornar Produto por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<ProdutoDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<ProdutoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ProdutoAccessControl.Read)]
        [HttpGet("get-by-id")]
        public async Task<ActionResult> GetById(Guid id)
        {
            var responseService = await _produtoService.RetornarPorId(id);
            return CustomResponse(responseService);
        }


        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>   

        [SwaggerOperation(Summary = "Cria-se um novo Grupo")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(GrupoAccessControl.Create)]

        [HttpPost("cadastrar-grupo")]
        public async Task<FormularioResponse<AdicionarGrupoCommand>> PostGrupo([FromBody] AdicionarGrupoRequestDto addGrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarGrupo(addGrupoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza o Grupo")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarGrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(GrupoAccessControl.Update)]

        [HttpPut("atualizar-grupo")]
        public async Task<FormularioResponse<AtualizarGrupoCommand>> PutGrupo([FromBody] AtualizarGrupoRequestDto updateGrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarGrupo(updateGrupoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Grupo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(GrupoAccessControl.Delete)]

        [HttpDelete("excluir-grupo")]
        public async Task<List<FormularioResponse<ExcluirGrupoCommand>>> Delete([FromBody] ExcluirGrupoDto deleteGrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteGrupoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Grupo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(GrupoAccessControl.Read)]
        [HttpGet("retornar-grupo")]
        public async Task<ActionResult> GetGrupo([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarGrupoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Grupo por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(GrupoAccessControl.Read)]

        [HttpGet("retornar-grupo-by-id")]
        public async Task<ActionResult> GetGrupoById(Guid id)
        {
            var responseService = await _produtoService.RetornarGrupoPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Cria-se um novo Codigo de Importacao")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(CodigoImportacaoAccessControl.Create)]  

        [HttpPost("cadastrar-codigo-importacao")]
        public async Task<FormularioResponse<AdicionarCodigoImportacaoCommand>> PostCodigo([FromBody] AdicionarCodigoImportacaoRequestDto addCodigoImportacaoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarCodigoImportacao(addCodigoImportacaoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza o Codigo de Importacao")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarCodigoImportacaoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(CodigoImportacaoAccessControl.Update)]

        [HttpPut("atualizar-codigo-importacao")]
        public async Task<FormularioResponse<AtualizarCodigoImportacaoCommand>> PutGrupo([FromBody] AtualizarCodigoImportacaoRequestDto updateCodigoImportacaoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarCodigoImportacao(updateCodigoImportacaoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Codigo de Importacao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(CodigoImportacaoAccessControl.Delete)]

        [HttpDelete("excluir-codigo-importacao")]
        public async Task<List<FormularioResponse<ExcluirCodigoImportacaoCommand>>> Delete([FromBody] ExcluirCodigoImportacaoDto deleteCodigoImportacaoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteCodigoImportacaoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Codigo de Importacao")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(CodigoImportacaoAccessControl.Read)]

        [HttpGet("retornar-codigo-importacao")]
        public async Task<ActionResult> GetCodigoImportacao([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarCodigoImportacaoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Codigo de Importacao por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(CodigoImportacaoAccessControl.Read)]

        [HttpGet("retornar-Codigo-importacao-by-id")]
        public async Task<ActionResult> GetCodigoImportacaoById(Guid id)
        {
            var responseService = await _produtoService.RetornarCodigoImportacaoPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se um novo Setor")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorAccessControl.Create)]

        [HttpPost("cadastrar-setor")]
        public async Task<FormularioResponse<AdicionarSetorCommand>> PostSetor([FromBody] AdicionarSetorRequestDto addSetorDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarSetor(addSetorDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza o Setor")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarSetorCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorAccessControl.Update)]

        [HttpPut("atualizar-setor")]
        public async Task<FormularioResponse<AtualizarSetorCommand>> PutSetor([FromBody] AtualizarSetorRequestDto updateSetorDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarSetor(updateSetorDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Setor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorAccessControl.Delete)]

        [HttpDelete("excluir-setor")]
        public async Task<List<FormularioResponse<ExcluirSetorCommand>>> Delete([FromBody] ExcluirSetorDto deleteSetorDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteSetorDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Setor")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(SetorAccessControl.Read)]

        [HttpGet("retornar-setor")]
        public async Task<ActionResult> GetSetor([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarSetorPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Setor por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorAccessControl.Read)]

        [HttpGet("retornar-setor-by-id")]
        public async Task<ActionResult> GetSetorById(Guid id)
        {
            var responseService = await _produtoService.RetornarSetorPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se uma nova Rua")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(RuaAccessControl.Create)]

        [HttpPost("cadastrar-rua")]
        public async Task<FormularioResponse<AdicionarRuaCommand>> PostRua([FromBody] AdicionarRuaRequestDto addRuaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarRua(addRuaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza a Rua")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarRuaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(RuaAccessControl.Update)]

        [HttpPut("atualizar-rua")]
        public async Task<FormularioResponse<AtualizarRuaCommand>> PutRua([FromBody] AtualizarRuaRequestDto updateRuaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarRua(updateRuaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove a Rua")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(RuaAccessControl.Delete)]

        [HttpDelete("excluir-rua")]
        public async Task<List<FormularioResponse<ExcluirRuaCommand>>> Delete([FromBody] ExcluirRuaDto deleteRuaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteRuaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Rua")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]       
        [CustomAuthorize(RuaAccessControl.Read)]

        [HttpGet("retornar-rua")]
        public async Task<ActionResult> GetRua([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarRuaPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retorna Rua por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(RuaAccessControl.Read)]

        [HttpGet("retornar-rua-by-id")]
        public async Task<ActionResult> GetRuaById(Guid id)
        {
            var responseService = await _produtoService.RetornarRuaPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>

        [SwaggerOperation(Summary = "Cria-se um novo SubGrupo")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SubgrupoAccessControl.Create)]

        [HttpPost("cadastrar-subgrupo")]
        public async Task<FormularioResponse<AdicionarSubgrupoCommand>> PostSubgrupo([FromBody] AdicionarSubgrupoRequestDto addSubgrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarSubgrupo(addSubgrupoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza-se o SubGrupo")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarSubgrupoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SubgrupoAccessControl.Update)]

        [HttpPut("atualizar-subgrupo")]
        public async Task<FormularioResponse<AtualizarSubgrupoCommand>> PutSubgrupo([FromBody] AtualizarSubgrupoRequestDto updateSubgrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarSubgrupo(updateSubgrupoDto, cancellationToken);
            return CustomResponse(responseService);       
        }

        [SwaggerOperation(Summary = "Remove o SubGrupo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SubgrupoAccessControl.Delete)]

        [HttpDelete("excluir-subgrupo")]
        public async Task<List<FormularioResponse<ExcluirSubgrupoCommand>>> Delete([FromBody] ExcluirSubgrupoDto deleteSubgrupoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteSubgrupoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de SubGrupo")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(SubgrupoAccessControl.Read)]

        [HttpGet("retornar-subgrupo")]
        public async Task<ActionResult> GetSubgrupo([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarSubgrupoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar SubGrupo por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SubgrupoAccessControl.Read)]

        [HttpGet("retornar-subgrupo-by-id")]
        public async Task<ActionResult> GetSubgrupoById(Guid id)
        {
            var responseService = await _produtoService.RetornarSubgrupoPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>

        [SwaggerOperation(Summary = "Cria-se uma nova Prateleira")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PrateleiraAccessControl.Create)]

        [HttpPost("cadastrar-prateleira")]

        public async Task<FormularioResponse<AdicionarPrateleiraCommand>> PostPrateleira([FromBody] AdicionarPrateleiraRequestDto addPrateleiraDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarPrateleira(addPrateleiraDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza a Prateleira")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarPrateleiraCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PrateleiraAccessControl.Update)]

        [HttpPut("atualizar-prateleira")]
        public async Task<FormularioResponse<AtualizarPrateleiraCommand>> PutPrateleira([FromBody] AtualizarPrateleiraRequestDto updatePrateleiraDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarPrateleira(updatePrateleiraDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove a Prateleira")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PrateleiraAccessControl.Delete)]

        [HttpDelete("excluir-prateleira")]
        public async Task<List<FormularioResponse<ExcluirPrateleiraCommand>>> Delete([FromBody] ExcluirPrateleiraDto deletePrateleiraDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deletePrateleiraDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Prateleira")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(PrateleiraAccessControl.Read)]

        [HttpGet("retornar-prateleira")]
        public async Task<ActionResult> GetPrateleira([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarPrateleiraPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Prateleira por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(PrateleiraAccessControl.Read)]

        [HttpGet("retornar-prateleira-by-id")]
        public async Task<ActionResult> GetPrateleiraById(Guid id)
        {
            var responseService = await _produtoService.RetornarPrateleiraPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se um novo Ncm")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(NcmAccessControl.Create)]

        [HttpPost("cadastrar-ncm")]
        public async Task<FormularioResponse<AdicionarNcmCommand>> PostNcm([FromBody] AdicionarNcmRequestDto addNcmDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarNcm(addNcmDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza o Ncm")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarNcmCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(NcmAccessControl.Update)]


        [HttpPut("atualizar-ncm")]
        public async Task<FormularioResponse<AtualizarNcmCommand>> PutNcm([FromBody] AtualizarNcmRequestDto updateNcmDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarNcm(updateNcmDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Ncm")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(NcmAccessControl.Read)]

        [HttpDelete("excluir-ncm")]
        public async Task<List<FormularioResponse<ExcluirNcmCommand>>> Delete([FromBody] ExcluirNcmDto deleteNcmDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteNcmDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Ncm")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<NcmDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<NcmDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]       
        [CustomAuthorize(NcmAccessControl.Read)]

        [HttpGet("retornar-ncm")]
        public async Task<ActionResult> GetNcm([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarNcmPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [CustomAuthorize(NcmAccessControl.Read)]

        [HttpGet("retornar-ncm-by-produto")]
        public async Task<ActionResult> RetornarNcmPorProduto(Guid id)
        {
            var responseService = await _produtoService.RetornarNcmPorProduto(id);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Ncm por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<NcmDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<NcmDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(NcmAccessControl.Read)]

        [HttpGet("retornar-ncm-by-id")]
        public async Task<ActionResult> GetNcmById(Guid id)
        {
            var responseService = await _produtoService.RetornarNcmPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se uma nova Familia")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FamiliaAccessControl.Create)]

        [HttpPost("cadastrar-familia")]
        public async Task<FormularioResponse<AdicionarFamiliaCommand>> PostFamilia([FromBody] AdicionarFamiliaRequestDto addFamiliaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarFamilia(addFamiliaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza a Familia")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarFamiliaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FamiliaAccessControl.Update)]

        [HttpPut("atualizar-familia")]
        public async Task<FormularioResponse<AtualizarFamiliaCommand>> PutFamilia([FromBody] AtualizarFamiliaRequestDto updateFamiliaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarFamilia(updateFamiliaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove a Familia")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FamiliaAccessControl.Delete)]

        [HttpDelete("excluir-familia")]
        public async Task<List<FormularioResponse<ExcluirFamiliaCommand>>> Delete([FromBody] ExcluirFamiliaDto deleteFamiliaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteFamiliaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Familia")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]      
        [CustomAuthorize(FamiliaAccessControl.Read)]

        [HttpGet("retornar-familia")]
        public async Task<ActionResult> GetFamilia([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarFamiliaPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Familia por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(FamiliaAccessControl.Read)]

        [HttpGet("retornar-familia-by-id")]
        public async Task<ActionResult> GetFamiliaById(Guid id)
        {
            var responseService = await _produtoService.RetornarFamiliaPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se uma nova Origem do Material")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(OrigemMaterialAccessControl.Create)]

        [HttpPost("cadastrar-origem-material")]
        public async Task<FormularioResponse<AdicionarOrigemMaterialCommand>> PostOrigemMaterial([FromBody] AdicionarOrigemMaterialRequestDto addOrigemMaterialDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarOrigemMaterial(addOrigemMaterialDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza Origem do Material")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarOrigemMaterialCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(OrigemMaterialAccessControl.Update)]

        [HttpPut("atualizar-origem-material")]
        public async Task<FormularioResponse<AtualizarOrigemMaterialCommand>> PutOrigemMaterial([FromBody] AtualizarOrigemMaterialRequestDto updateOrigemMaterialDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarOrigemMaterial(updateOrigemMaterialDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove a origem do Material")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(OrigemMaterialAccessControl.Delete)]

        [HttpDelete("excluir-origem-material")]
        public async Task<List<FormularioResponse<ExcluirOrigemMaterialCommand>>> Delete([FromBody] ExcluirOrigemMaterialDto deleteOrigemMaterialDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteOrigemMaterialDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Origem Material")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]        
        [CustomAuthorize(OrigemMaterialAccessControl.Read)]

        [HttpGet("retornar-origem-material")]
        public async Task<ActionResult> GetOrigemMaterial([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarOrigemMaterialPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Origem do Material por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(OrigemMaterialAccessControl.Read)]

        [HttpGet("retornar-origem-material-by-id")]
        public async Task<ActionResult> GetOrigemMaterialById(Guid id)
        {
            var responseService = await _produtoService.RetornarOrigemMaterialPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se Tipo de Produto")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoProdutoAccessControl.Create)]

        [HttpPost("cadastrar-tipo-produto")]
        public async Task<FormularioResponse<AdicionarTipoProdutoCommand>> PostTipoProduto([FromBody] AdicionarTipoProdutoRequestDto addTipoProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarTipoProduto(addTipoProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza tipo de Produto")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarTipoProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoProdutoAccessControl.Update)]

        [HttpPut("atualizar-tipo-produto")]
        public async Task<FormularioResponse<AtualizarTipoProdutoCommand>> PutTipoProduto([FromBody] AtualizarTipoProdutoRequestDto updateTipoProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarTipoProduto(updateTipoProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Tipo de Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoProdutoAccessControl.Delete)]

        [HttpDelete("excluir-tipo-produto")]
        public async Task<List<FormularioResponse<ExcluirTipoProdutoCommand>>> Delete([FromBody] ExcluirTipoProdutoDto deleteTipoProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteTipoProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Tipo de Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoProdutoAccessControl.Read)]

        [HttpGet("retornar-tipo-produto")]
        public async Task<ActionResult> GetTipoProduto([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarTipoProdutoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Tipo de Produto por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoProdutoAccessControl.Read)]

        [HttpGet("retornar-tipo-produto-by-id")]
        public async Task<ActionResult> GetTipoProdutoById(Guid id)
        {
            var responseService = await _produtoService.RetornarTipoProdutoPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se um tipo de Preco")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoPrecoAccessControl.Create)]

        [HttpPost("cadastrar-tipo-preço")]
        public async Task<FormularioResponse<AdicionarTipoPrecoCommand>> PostTipoPreco([FromBody] AdicionarTipoPrecoRequestDto addTipoPrecoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarTipoPreco(addTipoPrecoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza tipo de Preço")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarTipoPrecoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoPrecoAccessControl.Update)]

        [HttpPut("atualizar-tipo-preco")]
        public async Task<FormularioResponse<AtualizarTipoPrecoCommand>> PutTipoPreco([FromBody] AtualizarTipoPrecoRequestDto updateTipoPrecoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarTipoPreco(updateTipoPrecoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Tipo de Preco")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoPrecoAccessControl.Delete)]

        [HttpDelete("excluir-tipo-preco")]
        public async Task<List<FormularioResponse<ExcluirTipoPrecoCommand>>> Delete([FromBody] ExcluirTipoPrecoDto deleteTipoPrecoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteTipoPrecoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Tipo de Preco")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoPrecoAccessControl.Read)]
        [HttpGet("retornar-tipo-preco")]
        public async Task<ActionResult> GetTipoPreco([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarTipoPrecoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar tipo de Preço por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(TipoPrecoAccessControl.Read)]

        [HttpGet("retornar-Tipo-preco-by-id")]
        public async Task<ActionResult> GetTipoPrecoById(Guid id)
        {
            var responseService = await _produtoService.RetornarTipoPrecoPorId(id);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    

        [SwaggerOperation(Summary = "Cria-se um novo Setor de Produto")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Create)]

        [HttpPost("cadastrar-setor-produto")]
        public async Task<FormularioResponse<AdicionarSetorProdutoCommand>> PostSetorProduto([FromBody] AdicionarSetorProdutoRequestDto addSetorProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarSetorProduto(addSetorProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza Setor de Produto")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarSetorProdutoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Update)]

        [HttpPut("atualizar-setor-produto")]
        public async Task<FormularioResponse<AtualizarSetorProdutoCommand>> PutSetorProduto([FromBody] AtualizarSetorProdutoRequestDto updateSetorProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarSetorProduto(updateSetorProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove o Setor de Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Delete)]

        [HttpDelete("excluir-setor-produto")]
        public async Task<List<FormularioResponse<ExcluirSetorProdutoCommand>>> Delete([FromBody] ExcluirSetorProdutoDto deleteSetorProdutoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteSetorProdutoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Setor de Produto")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Read)]

        [HttpGet("retornar-setor-produto")]
        public async Task<ActionResult> GetSetorProduto([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarSetorProdutoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Setor de Produto por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Read)]

        [HttpGet("retornar-setor-produto-by-id")]
        public async Task<ActionResult> GetSetorProdutoById(Guid id)
        {
            var responseService = await _produtoService.RetornarSetorProdutoPorId(id);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Setor de Produto por Cadastro")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<SetorProdutoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<SetorProdutoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(SetorProdutoAccessControl.Read)]

        [HttpGet("retornar-setor-produto-by-cadastro")]
        public async Task<ActionResult> GetSetorProdutoCadastroById(bool mostrarCadastro)
        {
            var responseService = await _produtoService.RetornarSetorProdutoPorCadastro(mostrarCadastro);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Cria-se uma nova Unidade de Medida")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(UnidadeMedidaAccessControl.Create)]

        [HttpPost("cadastrar-unidade-medida")]
        public async Task<FormularioResponse<AdicionarUnidadeMedidaCommand>> PostUnidadeMedida([FromBody] AdicionarUnidadeMedidaRequestDto addUnidadeMedidaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarUnidadeMedida(addUnidadeMedidaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Atualiza Unidade De Medida")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AtualizarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarUnidadeMedidaCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(UnidadeMedidaAccessControl.Update)]

        [HttpPut("atualizar-unidade-medida")]
        public async Task<FormularioResponse<AtualizarUnidadeMedidaCommand>> PutUnidadeMedida([FromBody] AtualizarUnidadeMedidaRequestDto updateUnidadeMedidaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarUnidadeMedida(updateUnidadeMedidaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Remove a Unidade de Medida")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(UnidadeMedidaAccessControl.Delete)]

        [HttpDelete("excluir-unidade-medida")]
        public async Task<List<FormularioResponse<ExcluirUnidadeMedidaCommand>>> Delete([FromBody] ExcluirUnidadeMedidaDto deleteUnidadeMedidaDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.Excluir(deleteUnidadeMedidaDto, cancellationToken);
            return CustomResponse(responseService);
        }

        [SwaggerOperation(Summary = "Lista de Unidade de Medida")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(UnidadeMedidaAccessControl.Read)]

        [HttpGet("retornar-unidade-medida")]
        public async Task<ActionResult> GetUnidadeMedida([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarUnidadeMedidaPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        [SwaggerOperation(Summary = "Retornar Unidade de Medida por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<PadraoIdDescricaoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(UnidadeMedidaAccessControl.Read)]

        [HttpGet("retornar-unidade-medida-by-id")]
        public async Task<ActionResult> GetUnidadeMedidaById(Guid id)
        {
            var responseService = await _produtoService.RetornarUnidadeMedidaPorId(id);
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
        [SwaggerOperation(Summary = "Cria-se uma nova Classe de Reajuste")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ClasseReajusteAccessControl.Create)]
        [HttpPost("cadastrar-classe-reajuste")]
        public async Task<FormularioResponse<AdicionarClasseReajusteCommand>> PostClasseReajuste([FromBody] AdicionarClasseReajusteRequestDto addClasseReajusteDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarClasseReajuste(addClasseReajusteDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza a Classe de Reajuste")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarClasseReajusteCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(BancoAccessControl.Update)]
        [HttpPut("atualizar-classe-reajuste")]
        public async Task<FormularioResponse<AtualizarClasseReajusteCommand>> PutClasseReajuste([FromBody] AtualizarClasseReajusteRequestDto updateClasseReajusteDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarClasseReajuste(updateClasseReajusteDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui um ou mais Classe de Reajuste")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ClasseReajusteAccessControl.Delete)]
        [HttpDelete("excluir-classe-reajuste")]
        public async Task<List<FormularioResponse<ExcluirClasseReajusteCommand>>> Delete([FromBody] ExcluirClasseReajusteDto deleteClasseReajusteDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.ExcluirClasseReajuste(deleteClasseReajusteDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Classe de Reajuste")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<ClasseReajusteFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<ClasseReajusteFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ClasseReajusteAccessControl.Read)]

        [HttpGet("retornar-classe-reajuste")]
        public async Task<ActionResult> GetClasseReajuste([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarClasseReajustePaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Classe Reajuste por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<ClasseReajusteDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<ClasseReajusteDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ClasseReajusteAccessControl.Read)]

        [HttpGet("retornar-classe-reajuste-by-id")]
        public async Task<ActionResult> GetClasseReajusteById(Guid id)
        {
            var responseService = await _produtoService.RetornarClasseReajustePorId(id);
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
        [SwaggerOperation(Summary = "Cria-se um Parametro do Desgaste do Polimento")]
        [ProducesResponseType(StatusCodes.Status201Created, Type = typeof(Post201OKType<AdicionarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AdicionarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AdicionarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AdicionarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(DesgastePolimentoAccessControl.Create)]
        [HttpPost("cadastrar-desgaste-polimento")]
        public async Task<FormularioResponse<AdicionarDesgastePolimentoCommand>> PostDesgastePolimento([FromBody] AdicionarDesgastePolimentoRequestDto addDesgastePolimentoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AdicionarDesgastePolimento(addDesgastePolimentoDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Atualiza o Parametro do Desgaste do Polimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Update200OKType<AtualizarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status206PartialContent, Type = typeof(Post206OKListType<AtualizarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(Post207OKListType<AtualizarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400OKType<AtualizarDesgastePolimentoCommand>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(DesgastePolimentoAccessControl.Update)]
        [HttpPut("atualizar-desgaste-polimento")]
        public async Task<FormularioResponse<AtualizarDesgastePolimentoCommand>> PutDesgastePolimento([FromBody] AtualizarDesgastePolimentoRequestDto updateDesgastePolimentoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.AtualizarDesgastePolimento(updateDesgastePolimentoDto, cancellationToken);
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
        [SwaggerOperation(Summary = "Exclui um ou mais Parametros do Desgaste do Polimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Status200OKType<DeleteStatus200Type>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(List<Error400OKType<object>>))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status409Conflict, Type = typeof(Error409Conflict))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(DesgastePolimentoAccessControl.Delete)]
        [HttpDelete("excluir-desgaste-polimento")]
        public async Task<List<FormularioResponse<ExcluirDesgastePolimentoCommand>>> Delete([FromBody] ExcluirDesgastePolimentoDto deleteDesgastePolimentoDto, CancellationToken cancellationToken)
        {
            var responseService = await _produtoService.ExcluirDesgastePolimento(deleteDesgastePolimentoDto, cancellationToken);
            return CustomResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Lista de Desgaste de Polimento")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PaginationResponseType<DesgastePolimentoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(PaginationResponse207Type<DesgastePolimentoFilterDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(DesgastePolimentoAccessControl.Read)]

        [HttpGet("retornar-desgaste-polimento")]
        public async Task<ActionResult> GetDesgastePolimento([FromQuery] PaginacaoRequest paginationRequest)
        {
            var responseService = await _produtoService.RetornarDesgastePolimentoPaginacao(paginationRequest);
            return CustomPaginationResponse(responseService);
        }

        /// <response code="200"> Ok Result             - 0000 >> Dados encontrados.</response>
        /// <response code="207"> MultiStatus 			- 0000 >> Dados encontrados.</response>        
        /// <response code="400"> Bad Request			- 0000 >> Inativo ou não cadastrado! </response>
        /// <response code="401"> Unauthorized			- 0000 >> Houve um problema na sua autorização. </response>
        /// <response code="402"> Payment Required		- 0000 >> Houve um problema na confirmação de liberação de acesso. </response>
        /// <response code="403"> Forbidden			    - 0000 >> Houve um problema não foi possível realizar esta operação, entre em contato com suporte. </response>
        /// <response code="500"> InternalServerError	- 0000 >> Houve um problema no servidor, retornaremos em breve. Para mais detalhes entre em contato com o suporte. </response>    
        [SwaggerOperation(Summary = "Retornar Desgaste Polimento por Id")]
        [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(NewResponseType<DesgastePolimentoDto>))]
        [ProducesResponseType(StatusCodes.Status207MultiStatus, Type = typeof(NewResponse207Type<DesgastePolimentoDto>))]
        [ProducesResponseType(StatusCodes.Status400BadRequest, Type = typeof(Error400Get))]
        [ProducesResponseType(StatusCodes.Status401Unauthorized, Type = typeof(Error401Unauthorized))]
        [ProducesResponseType(StatusCodes.Status402PaymentRequired, Type = typeof(Error402PaymentRequired))]
        [ProducesResponseType(StatusCodes.Status403Forbidden, Type = typeof(Error403Forbidden))]
        [ProducesResponseType(StatusCodes.Status500InternalServerError, Type = typeof(Error500))]
        [CustomAuthorize(ClasseReajusteAccessControl.Read)]

        [HttpGet("retornar-desgaste-polimento-by-id")]
        public async Task<ActionResult> GetDesgastePolimentoById(Guid id)
        {
            var responseService = await _produtoService.RetornarDesgastePolimentoPorId(id);
            return CustomResponse(responseService);
        }
    }
}
